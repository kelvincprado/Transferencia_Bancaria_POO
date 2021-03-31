using System;
using System.Collections.Generic;

namespace Transferências_Bancárias
{
    class Program
    {
		static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario.ToUpper())
                {
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
                }
				opcaoUsuario = ObterOpcaoUsuario();
            }
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
        }

        private static void Transferir()
        {
			bool ok1 = false, ok2 = false;
			int indiceContaOrigem = -1, indiceContaDestino = -1;
			Console.Write("Digite o número da conta de origem: ");
			int NumeroContaOrigem = int.Parse(Console.ReadLine());
			Console.Write("Digite o número da conta de destino: ");
			int NumeroContaDestino = int.Parse(Console.ReadLine());
			for (int c = 0; c < listaContas.Count; c++)
			{
				int nconta1 = listaContas[c].NumeroConta;
				if (nconta1.Equals(NumeroContaOrigem))
				{
					indiceContaOrigem = c;
					ok1 = true;
				}
				int nconta2 = listaContas[c].NumeroConta;
				if (nconta2.Equals(NumeroContaDestino))
				{
					indiceContaDestino = c;
					ok2 = true;
				}

			}
			if (ok1 && indiceContaOrigem >= 0 && ok2 && indiceContaDestino >= 0)
			{
				Console.Write("Digite o valor a ser transferido: ");
				double valor = double.Parse(Console.ReadLine());
				listaContas[indiceContaOrigem].Transferir(valor, listaContas[indiceContaDestino]);
			}
			else
			{
				Console.WriteLine("Este número de conta não foi encontrado");
			}
		}

        private static void Depositar()
        {
			bool ok = false;
			int indiceConta = -1;
			Console.Write("Digite o número da conta: ");
			int NumeroConta = int.Parse(Console.ReadLine());
			for (int c = 0; c < listaContas.Count; c++)
			{
				int nconta = listaContas[c].NumeroConta;
				if (nconta.Equals(NumeroConta))
				{
					indiceConta = c;
					ok = true;
				}
			}
			if (ok && indiceConta >= 0)
			{
				Console.Write("Digite o valor a ser depositado: ");
				double valor = double.Parse(Console.ReadLine());
				listaContas[indiceConta].Depositar(valor);
			}
			else
			{
				Console.WriteLine("Este número de conta não foi encontrado");
			}
		}

        private static void Sacar()
        {
			bool ok = false;
			int indiceConta=-1;
			Console.Write("Digite o número da conta: ");
			int NumeroConta = int.Parse(Console.ReadLine());
			for (int c=0; c<listaContas.Count; c++)
            {
				int nconta = listaContas[c].NumeroConta;
                if (nconta.Equals(NumeroConta))
                {
					indiceConta =  c;
					ok = true;
                }
            }
			if (ok && indiceConta >= 0)
            {
				Console.Write("Digite o valor a ser sacado: ");
				double valor = double.Parse(Console.ReadLine());
				listaContas[indiceConta].Sacar(valor);
            }
            else
            {
				Console.WriteLine("Este número de conta não foi encontrado");
            }
			
			

        }

        private static void ListarContas()
        {
            if (listaContas.Count <= 0)
            {
				Console.WriteLine("Nenhuma conta cadastrada");
				return;
            }
            else
            {
				for(int i=0; i<listaContas.Count; i++)
                {
					Conta conta = listaContas[i];
					Console.Write($"Cliente: {i + 1} - ");
					Console.WriteLine(conta);
									
                }
            }
        }

        private static void InserirConta()
        {
			Console.WriteLine("Inserir nova conta");
			int entradaTipoConta = 0;

			do
			{
				Console.Write("Digite 1 para Conta Física ou 2 para Juridica: ");
				entradaTipoConta = int.Parse(Console.ReadLine());
			} while (entradaTipoConta != 1 && entradaTipoConta != 2);

			Console.Write("Digite o nome do cliente: ");
			String entradaNome = Console.ReadLine();

			Console.Write("Digite o número da conta: ");
			int entradaNumero = int.Parse(Console.ReadLine());

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = Double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = Double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
										numero: entradaNumero,
										saldo: entradaSaldo, 
										credito: entradaCredito, 
										nome: entradaNome);
			listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			
			Console.WriteLine("1 - Listar Contas");
			Console.WriteLine("2 - Inserir nova conta");
			Console.WriteLine("3 - Transferir");
			Console.WriteLine("4 - Sacar");
			Console.WriteLine("5 - Depositar");
			Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X - Sair");

			Console.Write("\nInforme a opção desejada: ");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
