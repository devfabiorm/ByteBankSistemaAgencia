using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Define uma Conta Corrente do Banco ByteBank. 
    /// </summary>
    public class ContaCorrente : IComparable
    {
        private static double TaxaOperacao;
        public static int TotalDeContasCriadas { get; private set; }
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }
        public Cliente Titular { get; set; }
        public int Agencia { get; }
        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return this._saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                else
                {
                    this._saldo = value;
                }
            }
        }

        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia">Representa o valor da propriedade <see cref="Agencia"/> e deve possuir um valor maior que zero.</param>
        /// <param name="numero">Representa o valor da propriedade <see cref="Numero"/> e deve possuir um valor maior que zero.</param>
        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento agência deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento número deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>
        /// </summary>
        /// <exception cref="ArgumentException">Exce~]ao lançada quando um valor negativo é usado no arumento <paramref name="valor"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o <paramref name="valor"/> é maior que o <see cref="Saldo"/></exception>
        /// <param name="valor">Representa o valor do saque. Deve ser maio que zero e menos que o <see cref="Saldo"/></param>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (this._saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            this._saldo -= valor;
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }

        public override string ToString()
        {
            //return "Agência " + Agencia + ", Número " + Numero + ", Saldo " + Saldo;
            return $"Agência {Agencia}, Número {Numero}, Saldo {Saldo}";
        }

        public override bool Equals(object obj)
        {
            ContaCorrente outraContaCorrente = obj as ContaCorrente;
            
            if(outraContaCorrente == null)
            {
                return false;
            }

            return this.Agencia == outraContaCorrente.Agencia && this.Numero == outraContaCorrente.Numero;
        }

        public int CompareTo(object obj)
        {
            var outraConta = obj as ContaCorrente;

            //Retornar negativo quanto a instância precede o obj
            //Retornar zero quando são iguais
            //Retornar positivo quanto o obj prercede a instância

            if(outraConta == null)
            {
                return -1;
            }

            if(Numero < outraConta.Numero)
            {
                return -1;
            }

            if(Numero == outraConta.Numero)
            {
                return 0;
            }

            return 1;
        }
    }
}
