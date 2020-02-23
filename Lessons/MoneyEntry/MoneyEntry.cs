using System;

namespace MoneyEntry
{
    public class MoneyEntry
    {
        private double _amount;

        public MoneyEntry()
        {
            _amount = 0;
            EntryDate = DateTime.Now;
        }

        public MoneyEntry(double amount, DateTime date)
        {
            _amount = amount;
            EntryDate = date;
        }

        public void InitWithString(string amount, string date)
        {
            Double.TryParse(amount, out _amount);

            DateTime dt;
            DateTime.TryParse(date, out dt);
            EntryDate = dt;
        }

        public override string ToString()
        {
            return string.Format("{0} from {1}", _amount, EntryDate.Date);
        }

        public bool isDebit
        {
            get
            {
                return (_amount > 0);
            }

            set
            {
                if (value && _amount < 0)
                    _amount = -_amount;
            }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public DateTime EntryDate { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}
