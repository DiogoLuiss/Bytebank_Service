using Csharp_avançado.Bill;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Csharp_avançado.Bytebank.Util
{
    public class ListCurrentsAccounts
    {
        public CurrentAccount[] _itens = null;
        private int _NextPosition = 0;

        public ListCurrentsAccounts(int initialSize = 5)
        {
            _itens = new CurrentAccount[initialSize];
        }

        public void Add(CurrentAccount account)
        {

         VerifyArrayCapacity(_NextPosition);

            //Console.WriteLine("Adicionando item");


            _itens[_NextPosition] = account;

            _NextPosition ++;

        }

        public void VerifyArrayCapacity (int CurrentCapacity)
        {
            if (CurrentCapacity < _itens.Length)
            {
                //Console.WriteLine("Tudo certo");
                return;
            }
            else
            {
                CurrentAccount[] NewArray = new CurrentAccount[CurrentCapacity + 1];

         

                for (int i = 0; i < _itens.Length; i++)
                {
                    NewArray[i] = _itens[i];
                }

                //Console.WriteLine($"Capacidade aumentada para {_itens.Length} ");

                _itens = NewArray;
          
            }
        }


        public void ShowAccounts ()
        {
            foreach (var item in _itens)
            {
                Console.WriteLine($"Nome: {item.Name}, Saldo: {item.BalanceAccount}, Numero da conta: {item.NumberAccount}.");
            }


        }

        public void RemoveAccount(CurrentAccount account)
        {

            var List = _itens.ToList();

            List.Remove(account);

            _itens = List.ToArray();
        }




    }

}

