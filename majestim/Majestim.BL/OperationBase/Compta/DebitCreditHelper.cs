using System;

namespace Majestim.BL.OperationBase.Compta
{
    public class DebitCreditHelper
    {
        private int _level;
        private (double debit, double credit )[] _values;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="debit"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        public static Sign SignOf(double? debit, double? credit)
        {
            double d = debit ?? 0;
            double c = credit ?? 0;
            double delta = Math.Abs(c - d);

            if (delta < 0.01) return Sign.Zero;

            return d > c ? Sign.Negative : Sign.Positive;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        public DebitCreditHelper(int level = 1)
        {
            this._level = level;
            this.Raz();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public (double debit, double credit) this[int index]
        {
            get
            {
                if (index < 0 || index >= this._level)
                    throw new Exception($"DebitCredit helper : index hors limite {index}");

                return this._values[index];
            }

            set
            {
                if (index < 0 || index >= this._level)
                    throw new Exception($"DebitCredit helper : index hors limite {index}");

                this._values[index] = value;
            }
        }

        /// <summary>
        /// ajouter un d/c sur un niveau et les niveau inderieurs
        /// </summary>
        /// <param name="index"></param>
        /// <param name="values"></param>
        public void Add(int index, (double? debit, double? credit) values)
        {
            if (index < 0 || index >= this._level)
                throw new Exception($"DebitCredit helper : index hors limite {index}");

            this.AddInternal(index, values);
        }

        /// <summary>
        /// ajouetr pour tous les niveaux
        /// </summary>
        /// <param name="index"></param>
        /// <param name="values"></param>
        private void AddInternal(int index, (double? debit, double? credit) values)
        {
            if (values.debit != null)
                this._values[index].debit += values.debit.Value;

            if (values.credit != null)
                this._values[index].credit += values.credit.Value;

            if (index > 0)
                this.AddInternal(index - 1, values);
        }

        /// <summary>
        /// raz
        /// </summary>
        public void Raz()
        {
            this._values = new (double, double)[this._level];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public (double? debit, double? credit) Solde(int index)
        {
            if (index < 0 || index >= this._level)
                throw new Exception($"DebitCredit helper : index hors limite {index}");

            (double? debit, double? credit) values = this._values[index];
            double? vdebit, vcredit;

            if (values.debit > values.credit)
            {
                vdebit = values.debit - values.credit;
                vcredit = null;
            }
            else
            {
                vdebit = null;
                vcredit = values.credit - values.debit;
            }

            return (vdebit, vcredit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double GetSolde(int index)
        {
            if (index < 0 || index >= this._level)
                throw new Exception($"DebitCredit helper : index hors limite {index}");

            return this._values[index].credit - this._values[index].debit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool NotZero(int index)
        {
            if (index < 0 || index >= this._level)
                throw new Exception($"DebitCredit helper : index hors limite {index}");

            return this._values[index].credit != 0 || this._values[index].debit != 0;
        }
    }
}