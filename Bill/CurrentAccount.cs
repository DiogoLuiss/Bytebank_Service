using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_avançado.Bill
{
    public class CurrentAccount: IComparable<CurrentAccount>
    {
        public string Name {get; set;}

        public double NumberAccount { get;  set; }

        public double BalanceAccount { get; set; }

      public CurrentAccount(string Name, double NumberAccount, double BalanceAccount)
        {
            this.NumberAccount = NumberAccount;
            this.Name = Name;
            this.BalanceAccount = BalanceAccount;
        }

        public int CompareTo(CurrentAccount? other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.Name.CompareTo(other.Name);


        }

        public override string ToString()
        {
            return $"Nome da conta: {this.Name}, Numero da conta: {this.NumberAccount}, Saldo da conta: {this.BalanceAccount}";
        }

    }
}
