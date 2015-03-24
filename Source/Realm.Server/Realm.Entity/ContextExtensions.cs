using Realm.Entity.Contexts;
using Realm.Library.Common;

namespace Realm.Entity
{
    /// <summary>
    ///
    /// </summary>
    public static class ContextExtensions
    {
        /// <summary>
        /// Users has the proper flags to be an admin
        /// </summary>
        public static bool IsAdmin(this IFlagContext flags)
        {
            Validation.IsNotNull(flags, "flags");

            return flags.HasFlag("Wizard") || flags.HasFlag("Admin");
        }

        /// <summary>
        /// User has the proper flags to be a builder
        /// </summary>
        public static bool IsBuilder(this IFlagContext flags)
        {
            Validation.IsNotNull(flags, "flags");

            return flags.IsAdmin() || flags.HasFlag("Builder");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static bool IsWizard(this IFlagContext flags)
        {
            Validation.IsNotNull(flags, "flags");

            return flags.HasFlag("Wizard");
        }
    }
}