using System;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    /// <summary>
    /// encarregado pelo CRUD
    /// Armazenar, Recuperar, Atualizar, Excluir
    /// 
    /// CONTROLLER = COORDENAÇÃO
    /// </summary>
    public class ControladorEquipamento : ControladorBase
    {

        public string RegistrarEquipamento(int id, string nome, double preco,
            string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            Equipamento equipamento = null;

            int posicao = ObterPosicaoParaEquipamentos(id);

            if (id == 0)
                equipamento = new Equipamento();
            else
                equipamento = (Equipamento)registros[posicao];
            
            equipamento.nome = nome;
            equipamento.preco = preco;
            equipamento.numeroSerie = numeroSerie;
            equipamento.dataFabricacao = dataFabricacao;
            equipamento.fabricante = fabricante;

            string resultadoValidacao = equipamento.Validar();

            if (resultadoValidacao == "EQUIPAMENTO_VALIDO")
                registros[posicao] = equipamento;

            return resultadoValidacao;
        }

        public Equipamento SelecionarEquipamentoPorId(int id)
        {
            return (Equipamento)SelecionarRegistroPorId(new Equipamento(id));
        }

        public bool ExcluirEquipamento(int idSelecionado)
        {
            return ExcluirRegistro(new Equipamento(idSelecionado));
        }

        public Equipamento[] SelecionarTodosEquipamentos()
        {
            return Array.ConvertAll(SelecionarTodosRegistros(), e => (Equipamento)e);
        }

        #region métodos privados
        private int QtdEquipamentosCadastrados()
        {
            int numeroEquipamentosCadastrados = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    numeroEquipamentosCadastrados++;
                }
            }

            return numeroEquipamentosCadastrados;
        }
        private int ObterPosicaoParaEquipamentos(int idEquipamentoSelecionado)
        {
            return ObterPosicaoParaRegistros(new Equipamento(idEquipamentoSelecionado), idEquipamentoSelecionado);
        }
        #endregion
    }
}