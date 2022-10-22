using Microsoft.AspNetCore.Authorization;

namespace Extensions;
public static class PoliciesExtensions
{
    public static void AddPolicy(this AuthorizationOptions policy, string policyName,
        params string[] rolePolicy)
    {
        policy.AddPolicy(policyName,
            policy => policy.RequireRole(rolePolicy));
    }
}