using System;

public class Conta{

	private TipoConta TipoConta { get; set; }

	private double Saldo { get; set; }

	private double Credito { get; set; }

	private string Nome { get; set; }

	public int NumeroConta { get; set; }

	public Conta(TipoConta tipoConta, int numero, double saldo, double credito, string nome){
		this.TipoConta = tipoConta;
		this.NumeroConta = numero;
		this.Saldo = saldo;
		this.Credito = credito;
		this.Nome = nome;
	}

	public bool Sacar(double valorSaque)
    {
		if(this.Saldo - valorSaque < (this.Credito * -1))
        {
			Console.WriteLine("Saldo insuficiente!");
			return false;
        }
        else
        {
			this.Saldo -= valorSaque;
			Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
			return true;
		}
		
    }

	public void Depositar(Double valorDeposito)
    {
		this.Saldo += valorDeposito;
		Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
    }

	public void Transferir(double valorTransferencia, Conta contaDestino)
    {
        if (this.Sacar(valorTransferencia))
        {
			contaDestino.Depositar(valorTransferencia);
        }
    }

	public override string ToString()
    {
		string msg = "";
		msg += "Tipo Conta: " + this.TipoConta + " | ";
		msg += "Nome: " + this.Nome + " | ";
		msg += "Número da conta: " + this.NumeroConta + " | ";
		msg += "Saldo: " + this.Saldo + " | ";
		msg += "Crédito: " + this.Credito;
		return msg;
	}

	public int numeroConta()
    {
		return this.NumeroConta;
    }
}
