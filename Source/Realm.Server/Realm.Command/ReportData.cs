using Realm.Library.Common;

namespace Realm.Command
{
    /// <summary>
    ///
    /// </summary>
    public class ReportData
    {
        /// <summary>
        ///
        /// </summary>
        public IEntity Actor { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEntity Victim { get; set; }

        /// <summary>
        ///
        /// </summary>
        public object DirectObject { get; set; }

        /// <summary>
        ///
        /// </summary>
        public object IndirectObject { get; set; }

        /// <summary>
        ///
        /// </summary>
        public object Space { get; set; }

        /// <summary>
        ///
        /// </summary>
        public object Extra { get; set; }
    }
}