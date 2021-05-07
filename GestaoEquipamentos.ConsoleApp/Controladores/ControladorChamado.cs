using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorChamado : ControladorBase
    {
        private ControladorSolicitante controladorSolicitante;
        private ControladorEquipamento controladorEquipamento;

        public ControladorChamado(int capacidadeRegistros, ControladorEquipamento controlador, ControladorSolicitante controladorS)
        {
            controladorEquipamento = controlador;
            controladorSolicitante = controladorS;
        }

        public void RegistrarChamado(int idChamadoSelecionado,int idSolicitanteChamado, int idEquipamentoChamado, 
            string titulo, string descricao, DateTime dataAbertura)
        {
            Chamado chamado = null;

            int posicao = ObterPosicaoParaChamados(idChamadoSelecionado);

            if (idChamadoSelecionado == 0)
                chamado = new Chamado();
            else
                chamado = (Chamado)registros[posicao];

            Chamado novoChamado = new Chamado();
            novoChamado.solicitante = controladorSolicitante.SelecionarSolicitantePorId(idSolicitanteChamado);
            novoChamado.equipamento = controladorEquipamento.SelecionarEquipamentoPorId(idEquipamentoChamado);
            novoChamado.titulo = titulo;
            novoChamado.descricao = descricao;
            novoChamado.dataAbertura = dataAbertura;

            registros[posicao] = novoChamado;
        }

        public bool ExcluirChamado(int idSelecionado)
        {
            return ExcluirRegistro(new Chamado(idSelecionado));
        }

        public int ObterPosicaoParaChamados(int idChamadoSelecionado)
        {
            return ObterPosicaoParaRegistros(new Chamado(idChamadoSelecionado), idChamadoSelecionado);
        }

        public Chamado[] SelecionarTodosChamados()
        {
            return Array.ConvertAll(SelecionarTodosRegistros(), e => (Chamado)e);
        }

    }
}
