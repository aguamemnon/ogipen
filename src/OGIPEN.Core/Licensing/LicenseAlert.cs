namespace OGIPEN.Core.Licensing;

public enum LicenseAlertSeverity { None, Warning, Critical }
public enum LicenseAlertCode
{
    Valid,
    Missing,
    Invalid,
    Expiring30Days,
    Expiring15Days,
    ExpiringToday,
    Expired,
    Expired15Days,
    Expired30Days
}

/// <summary>
/// The expiry date is inclusive, in UTC. A licence that expires on today's
/// date is still in its final day; from tomorrow, it is expired.
/// Negative day offsets represent days elapsed after expiry.
/// </summary>
public sealed record LicenseAlert(
    LicenseAlertCode Code,
    LicenseAlertSeverity Severity,
    string Title,
    string Description,
    int? DaysUntilExpiry,
    bool BlocksLicensedFeatures);

public static class LicenseAlertEvaluator
{
    public static LicenseAlert Evaluate(
        DateOnly? expiresOnUtc, bool cryptographicallyVerified,
        DateOnly todayUtc)
    {
        if (expiresOnUtc is null)
            return new(LicenseAlertCode.Missing, LicenseAlertSeverity.Critical,
                "Aucune licence OGIPEN",
                "Aucune licence signée n'a été vérifiée. Activation nécessaire.",
                null, true);

        if (!cryptographicallyVerified)
            return new(LicenseAlertCode.Invalid, LicenseAlertSeverity.Critical,
                "Licence non authentifiée",
                "La signature de la licence n'a pas été validée.",
                null, true);

        int remaining = expiresOnUtc.Value.DayNumber - todayUtc.DayNumber;

        if (remaining < -29)
            return new(LicenseAlertCode.Expired30Days, LicenseAlertSeverity.Critical,
                "Licence expirée depuis 30 jours ou plus",
                $"Licence expirée depuis {-remaining} jours. Renouvellement nécessaire.",
                remaining, true);
        if (remaining <= -15)
            return new(LicenseAlertCode.Expired15Days, LicenseAlertSeverity.Critical,
                "Licence expirée depuis 15 jours ou plus",
                $"Licence expirée depuis {-remaining} jours. Renouvellement nécessaire.",
                remaining, true);
        if (remaining < 0)
            return new(LicenseAlertCode.Expired, LicenseAlertSeverity.Critical,
                "Licence expirée",
                $"Licence expirée depuis {-remaining} jour(s). Renouvellement nécessaire.",
                remaining, true);
        if (remaining == 0)
            return new(LicenseAlertCode.ExpiringToday, LicenseAlertSeverity.Warning,
                "Dernier jour de validité",
                "Votre licence OGIPEN expire aujourd'hui.",
                remaining, false);
        if (remaining <= 15)
            return new(LicenseAlertCode.Expiring15Days, LicenseAlertSeverity.Warning,
                "Expiration prochaine de la licence",
                $"Votre licence expire dans {remaining} jour(s).",
                remaining, false);
        if (remaining <= 30)
            return new(LicenseAlertCode.Expiring30Days, LicenseAlertSeverity.Warning,
                "Renouvellement de licence à prévoir",
                $"Votre licence expire dans {remaining} jour(s).",
                remaining, false);

        return new(LicenseAlertCode.Valid, LicenseAlertSeverity.None,
            "Licence active", "Votre licence OGIPEN est en cours de validité.",
            remaining, false);
    }
}
