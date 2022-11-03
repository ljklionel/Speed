using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;
using System.Text.Json;

// we create a new class that inherits from the AccountClaimsPrincipalFactory class and overrides the CreateUserAsync method.
// We use the AccountClaimsPrincipalFactory class to enable a default implementation for converting a RemoteUserAccount into a ClaimsPrincipal.
// In the overridden CreateUserAsync method, we extract the ClaimsIdentity from the created user and call the MapArrayClaimsToMultipleSeparateClaims method.
// In this method, we iterate through every property from the account’s AdditionalProperties collection and if we find the value and that value is a JSON array, we map each element of the array as a separate claim.
namespace Speed.Client
{
    public class CustomUserFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {
        public CustomUserFactory(IAccessTokenProviderAccessor accessor)
        : base(accessor)
        {
        }
        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(
            RemoteUserAccount account,
            RemoteAuthenticationUserOptions options)
        {
            var user = await base.CreateUserAsync(account, options);
            var claimsIdentity = (ClaimsIdentity)user.Identity;
            if (account != null)
            {
                MapArrayClaimsToMultipleSeparateClaims(account, claimsIdentity);
            }
            return user;
        }
        private void MapArrayClaimsToMultipleSeparateClaims(RemoteUserAccount account, ClaimsIdentity claimsIdentity)
        {
            foreach (var prop in account.AdditionalProperties)
            {
                var key = prop.Key;
                var value = prop.Value;
                if (value != null &&
                    (value is JsonElement element && element.ValueKind == JsonValueKind.Array))
                {
                    claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(prop.Key));
                    var claims = element.EnumerateArray()
                        .Select(x => new Claim(prop.Key, x.ToString()));
                    claimsIdentity.AddClaims(claims);
                }
            }
        }
    }
}
