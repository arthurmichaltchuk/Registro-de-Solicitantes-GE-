using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaChamado : Tela
    {
        private TelaEquipamento telaEquipamento;
        private ControladorChamado controladorChamado;
        private TelaSolicitante telaSolicitante;
        private ControladorSolicitante controladorSolicitante;

        public TelaChamado(ControladorChamado controlador ,TelaEquipamento tela, TelaSolicitante telaS)
        {
            controladorChamado = controlador;           
            telaEquipamento = tela;
            telaSolicitante = telaS;
        }

        public override void Excluir()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            controladorChamado.ExcluirChamado(idSelecionado);
        }

        public override void Editar()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Registrar(idSelecionado);
        }

        public override void Visualizar()
        {
            Console.Clear();

            MontarCabecalhoTabela();

            Chamado[] chamados = controladorChamado.SelecionarTodosChamados();

            foreach (Chamado chamado in chamados)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-35} | {3,-25} | {4,-25}", 
                chamado.id, chamado.equipamento.nome, chamado.titulo, chamado.DiasEmAberto, chamado.solicitante.nome);
            }

            if (chamados.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum chamado registrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        private static void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-35} | {3,-25} | {4,-25}", "Id", "Equipamento", "Título", "Dias em Aberto", "Solicitante");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        public override void Registrar(int idChamadoSelecionado)
        {
            
            Console.Clear();

            telaSolicitante.Visualizar();
            Console.Write("Digite o ID do solicitante para atribuir: ");
            int idSolicitanteChamado = Convert.ToInt32(Console.ReadLine());

            telaEquipamento.Visualizar();
            Console.Write("Digite o ID do equipamento para manutenção: ");
            int idEquipamentoChamado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o titulo do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            
            controladorChamado.RegistrarChamado(idChamadoSelecionado, idSolicitanteChamado, idEquipamentoChamado, titulo, descricao, dataAbertura);
        }       
    }
}
