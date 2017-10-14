using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    /// <summary>
    /// Clase encargada de administrar una cuenta bancaria.
    /// </summary>
    public class BankAccount
    {
        // class under test  
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";

        private string _customerName;
        private double _balance;
        private bool _frozen;

        /// <summary>
        /// Constructor de clase que administra cuenta bancaria.
        /// </summary>
        /// <param name="customerName">Nombre de cliente para inicializar la cuenta</param>
        /// <param name="balance">Saldo inicial de cuenta bancaria para el cliente del parametro anterior</param>
        public BankAccount (string customerName, double balance)
        {
            _customerName = customerName;
            _balance = balance;
        }

        /// <summary>
        /// Por medio de esta propiedad obtenemos el nombre del cliente de la clase instanciada (objeto)
        /// </summary>
        public string CustomerName
        {
            get { return _customerName; }
        }
        /// <summary>
        /// Por medio de esta propiedad obtenemos el saldo de cuenta de la clase instanciada (objeto)
        /// </summary>
        public double Balance
        {
            get { return _balance; }
        }
        /// <summary>
        /// Realizar un debito a la cuenta bancaria instanciada.
        /// </summary>
        /// <param name="amount">Monto a debitar</param>
        public void Debit(double amount)
        {
            if (_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException("amount",amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            _balance -= amount; // Codigo hecho intencionalmente para que falle. 
        }
        /// <summary>
        /// Realizar un credito a la cuenta bancaria instanciada.
        /// </summary>
        /// <param name="amount">Monto a acreditar</param>
        public void Credit(double amount)
        {
            if (_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            _balance += amount;
        }

        /// <summary>
        /// Metodo para congelar una cuenta bancaria por razones predeterminadas por el usuario.
        /// </summary>
        public void FreezeAccount()
        {
            _frozen = true;
        }

        /// <summary>
        /// Metodo para descongelar una cuenta.
        /// </summary>
        public void UnfreezeAccount()
        {
            _frozen = false;
        }

        /// <summary>
        /// Metodo de ejecución principal
        /// </summary>
        /// <param name="args">Parametros de entrada a la ejecución principal.</param>
        static void Main(string[] args)
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);
            try
            {
                //ba.Credit(5.77);
                ba.Debit(-100);
                Console.WriteLine("Current balance is ${0}", ba.Balance);
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
