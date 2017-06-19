using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitcoin_Transaction_Log
{
    /// <summary>
    /// Contains row data.
    /// </summary>
    public class DataGridSettingsRow
    {
        public string Transaction;
        public string Date;
        public string BTC;
        public string USD;
        public string Fee;
        public string ExchangeRate;
        public bool Disabled = false;
        public string Comments;

        public DataGridSettingsRow(object _transaction, object _date, object _btc, object _usd, object _fee, object _exchangeRate, object _disabled, object _comments)
        {
            Transaction = Convert.ToString(_transaction);
            BTC = Convert.ToString(_btc);
            Date = Convert.ToString(_date);
            USD = Convert.ToString(_usd);
            Fee = Convert.ToString(_fee);
            ExchangeRate = Convert.ToString(_exchangeRate);
            Disabled = Convert.ToBoolean(_disabled);
            Comments = Convert.ToString(_comments);
        }
    }
}
