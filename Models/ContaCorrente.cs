using System;

namespace Models
{
  /// <summary>
  /// Define uma Conta Corrente do banco ByteBank;
  /// </summary>
  public class ContaCorrente
  {
    public int ContadorSaquesNaoPermitidos { get; private set; }
    public int ContadorTransferenciasNaoPermitidas { get; private set; }
    public static double TaxaOperacional;
    public static int TotalDeContasCriadas { get; private set; }
    public Cliente Titular { get; set; }
    public int Numero { get; }
    public int Agencia { get; }
    private decimal _saldo { get; set; }
    public decimal Saldo
    {
      get
      {
        return _saldo;
      }
      set
      {
        if (value < 0)
        {
          return;
        }
        _saldo = value;
      }
    }
    /// <summary>
    /// Cria uma instancia de ContaCorrente com os seguintes parametros:
    /// </summary>
    /// <param name="agencia"> Propriedade <see cref="Agencia"/>, deve possuir valor > 0</param>
    /// <param name="numero">  Propriedade <see cref="Numero"/>, deve possuir valor > 0</param>
    public ContaCorrente(int agencia, int numero)
    {
      if (numero <= 0)
      {
        throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
      }

      if (numero <= 0)
      {
        throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
      }

      Agencia = agencia;
      Numero = numero;

      TotalDeContasCriadas++;
      TaxaOperacional = 30 / TotalDeContasCriadas;
    }

    /// <summary>
    /// Realiza o Saque e atualiza o valor da propriedade <see cref="Saldo"/>
    /// </summary>
    /// <exception cref="ArgumentException"> Excessao lancada quando e passado um valor negativo para o argumento <paramref name="valor"/></exception>
    /// <exception cref="SaldoInsuficienteException"> Excessao lancada quando o valor de <see cref="Saldo"/> e insuficiente</exception>
    /// <param name="valor">Deve ser maior que  0  e menor que o <see cref="Saldo"/></param>
    public void Sacar(decimal valor)
    {
      if (valor < 0)
      {
        throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
      }

      if (_saldo < valor)
      {
        ContadorSaquesNaoPermitidos++;
        throw new SaldoInsuficienteException(Saldo, valor);
      }

      _saldo -= valor;
    }

    public void Depositar(decimal valor)
    {
      _saldo += valor;
    }

    public void Transferir(decimal valor, ContaCorrente contaDestino)
    {
      if (valor < 0)
      {
        throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
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
  }
}
