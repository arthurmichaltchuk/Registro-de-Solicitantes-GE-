using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaSolicitante : Tela
    {
        //atributo
        private ControladorSolicitante controladorSolicitante;

        public TelaSolicitante(ControladorSolicitante solicitante)
        {
            controladorSolicitante = solicitante;
        }


        public override void Editar()
        {
            //visualiza os equipamentos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual equipamento atualizar
            Console.Write("Digite o número do solicitante que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            //atualiza o equipamento
            Registrar(idSelecionado);
        }

        public override void Excluir()
        {
            //visualização dos equipamentos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual equipamento excluir
            Console.Write("Digite o número do solicitante que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorSolicitante.ExcluirSolicitante(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Registro excluído com sucesso");
                Console.ReadLine();
            }
        }

        public override void Visualizar()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Solicitante[] solicitante = controladorSolicitante.SelecionarTodosSolicitantes();

            for (int i = 0; i < solicitante.Length; i++)
            {
                Console.Write(configuracaColunasTabela,
                   solicitante[i].id, solicitante[i].nome, solicitante[i].email);

                Console.WriteLine();
            }

            if (solicitante.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum solicitante cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public override void Registrar(int id)
        {
            Console.Clear();


            
            
                Console.Write("Digite o nome do solicitante: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o email do solicitante: ");
                string email = Console.ReadLine();

                Console.Write("Digite o número de telefone do solicitante: ");
                string numeroTelefone = Console.ReadLine();

                string resultadoValidacao = controladorSolicitante.RegistrarSolicitante(id, nome, email, numeroTelefone);

                if (resultadoValidacao != "SOLICITANTE_VALIDO")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(resultadoValidacao);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registro gravado com sucesso!");
                }

                Console.ReadLine();
                Console.Clear();
                Console.ResetColor();

        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Email");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        #endregion
    }

}

