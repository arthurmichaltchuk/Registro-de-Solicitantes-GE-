using System;
using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Telas;

namespace GestaoEquipamentos.ConsoleApp
{
    partial class Program
    {
        #region Especificação 
        /** Requisito 1.1 [OK] [12,5 % Concluído]
         * Como funcionário, Junior quer ter a possibilidade 
         * de registrar equipamentos
    
            Critérios:
        
             •  Deve ter um nome com no mínimo 6 caracteres;  
             •  Deve ter um preço de aquisição;  
             •  Deve ter um número de série;  
             •  Deve ter uma data de fabricação;  
             •  Deve ter uma fabricante; 
         */

        /** Requisito 1.2 [OK] [25% Concluído]
         * Como funcionário, Junior quer ter a possibilidade 
         * de visualizar todos os equipamentos registrados em seu inventário
    
            Critérios:
        
             •  Deve mostrar o nome;  
             •  Deve mostrar o preço de aquisição;  
             •  Deve mostrar o número de série;  
             •  Deve mostrar a data de fabricação;  
             •  Deve mostrar o fabricante; 
         */

        /** Requisito 1.3 [OK] [37,5% Concluído]
         * Como funcionário, Junior quer ter a possibilidade 
         * de editar um equipamento, sendo que ele possa editar todos os campos
    
            Critérios:
        
             •  Deve ter os mesmos critérios que o Requisito 1.1
         */

        /** Requisito 1.4 [OK] [50% Concluído]
         * 
         * Como funcionário, Junior quer ter a possibilidade 
         * de excluir um equipamento que esteja registrado.    
         * 
         *    •   A lista de equipamentos deve ser atualizada
         */

        /** Requisito 2.1 [OK] [62,5% Concluído]
         * 
         * Como funcionário, Junior quer ter a possibilidade 
         * de registrar os chamados de manutenções que são efetuadas nos equipamentos registrados    
         * 
                 •  Deve ter a título do chamado;  
                 •  Deve ter a descrição do chamado;  
                 •  Deve ter um equipamento;  
                 •  Deve ter uma data de abertura;   
         */

        /** Requisito 2.2 [OK] [75% Concluído]
        * 
        * Como funcionário, Junior quer ter a possibilidade de
        * visualizar todos os chamados registrados para controle.   
        * 
                •  Deve ter o id do chamado;  
                •  Deve ter a título do chamado;  
                •  Deve ter a descrição do chamado;  
                •  Deve ter um equipamento;  
                •  Deve ter uma data de abertura;   
        */

        /** Requisito 2.3 [OK] [87,5% Concluído]
        * 
        * Como funcionário, Junior quer ter a possibilidade de
        * editar um chamado que esteja registrado, sendo que ele possa editar todos os campos   
        * 
                •  Deve ter os mesmos critérios que o Requisito 2.1  
        */

        /** Requisito 2.4 [OK] [100% Concluído]
        * 
        * Como funcionário, Junior quer ter a possibilidade
        * de excluir um chamado
        * 
                •  A lista de chamados deve ser atualizada 
        */
        #endregion

        const int CAPACIDADE_REGISTROS = 100;

        static void Main(string[] args)
        {
            ControladorEquipamento controladorEquipamento = new ControladorEquipamento();
            ControladorSolicitante controladorSolicitante = new ControladorSolicitante();

            TelaEquipamento telaEquipamento = new TelaEquipamento(controladorEquipamento);

            ControladorChamado controladorChamado = new ControladorChamado(CAPACIDADE_REGISTROS, controladorEquipamento, controladorSolicitante); 
            TelaSolicitante telaSolicitante = new TelaSolicitante(controladorSolicitante);

            Tela telaMae = null;

            ControladorBase controladorBase = null;

       
            Console.Clear();
            
            while (true)
            {
                string opcao = ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    break;
                if (opcao == "1")
                    telaMae = new TelaEquipamento(controladorEquipamento);
                else if (opcao == "2")
                    telaMae = new TelaChamado(controladorChamado, telaEquipamento, telaSolicitante);
                else if (opcao == "3")
                    telaMae = new TelaSolicitante(controladorSolicitante);


                Console.Clear();
                    string opcaoCadastroEquipamentos = Program.ObterControle();

                    if (opcaoCadastroEquipamentos.Equals("s", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (opcaoCadastroEquipamentos == "1")
                        telaMae.Registrar(0);

                    else if (opcaoCadastroEquipamentos == "2")
                        telaMae.Visualizar();

                    else if (opcaoCadastroEquipamentos == "3")
                        telaMae.Editar();

                    else if (opcaoCadastroEquipamentos == "4")
                        telaMae.Excluir();
                    Console.Clear();
                           
            }
        }

        private static string ObterOpcao()
        {
            //CRUD (Create, Retrieve, Update, Delete)
            Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
            Console.WriteLine("Digite 2 para o Controle de Chamados");
            Console.WriteLine("Digite 3 para o Cadastro de Solicitantes");

            Console.WriteLine("Digite S para Sair");

            string opcao = Console.ReadLine();
            return opcao;
        }
        public static string ObterControle()
        {
            Console.WriteLine("Digite 1 para inserir novo");
            Console.WriteLine("Digite 2 para visualizar");
            Console.WriteLine("Digite 3 para editar");
            Console.WriteLine("Digite 4 para excluir");
            Console.WriteLine("Digite 5 para voltar");
            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
