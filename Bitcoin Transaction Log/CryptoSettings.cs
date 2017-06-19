using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitcoin_Transaction_Log
{
    /// <summary>
    /// Settings for a specific cryptocurrency.
    /// </summary>
    public class CryptoSettings
    {
        /// <summary>
        /// DataGridView row data.
        /// </summary>
        public List<DataGridSettingsRow> Rows = new List<DataGridSettingsRow>();

        /// <summary>
        /// Price alerts enabled flag.
        /// </summary>
        public bool PriceAlertsEnabled = true;

        /// <summary>
        /// Price alerts list. (Greater than or equal to)
        /// </summary>
        public List<decimal> PriceAlertsG = new List<decimal>();

        /// <summary>
        /// Price alerts list. (Less than or equal to)
        /// </summary>
        public List<decimal> PriceAlertsL = new List<decimal>();
    }
}
