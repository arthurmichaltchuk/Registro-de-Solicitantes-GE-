using GestaoEquipamentos.ConsoleApp.Dominio;
using System;


namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorSolicitante : ControladorBase
    {
        public string RegistrarSolicitante(int id, string nome, string email, string numeroTelefone)
        {
            Solicitante solicitante;

            int posicao = ObterPosicaoParaSolicitante(id);

            if (id == 0)
                solicitante = new Solicitante();
            else
                solicitante = (Solicitante)registros[posicao];

            solicitante.nome = nome;
            solicitante.email = email;
            solicitante.numeroTelefone = numeroTelefone;

            string resultadoValidacao = solicitante.Validar();

            if (resultadoValidacao == "SOLICITANTE_VALIDO")
                registros[posicao] = solicitante;

            return resultadoValidacao;
        }

        public bool ExcluirSolicitante(int idSelecionado)
        {
            return ExcluirRegistro(new Solicitante(idSelecionado));
        }

        public Solicitante[] SelecionarTodosSolicitantes()
        {
            return Array.ConvertAll(SelecionarTodosRegistros(), s => (Solicitante)s);
        }

        #region métodos privados
        //private int QtdEquipamentosCadastrados()
        //{
        //    int numeroEquipamentosCadastrados = 0;

        //    for (int i = 0; i < registros.Length; i++)
        //    {
        //        if (registros[i] != null)
        //        {
        //            numeroEquipamentosCadastrados++;
        //        }
        //    }

        //    return numeroEquipamentosCadastrados;
        //}

        public Solicitante SelecionarSolicitantePorId(int id)
        {
            return (Solicitante)SelecionarRegistroPorId(new Solicitante(id));
        }

        private int ObterPosicaoParaSolicitante(int idSolicitanteSelecionado)
        {
            return ObterPosicaoParaRegistros(new Solicitante(idSolicitanteSelecionado), idSolicitanteSelecionado);
        }
        #endregion
    }
}
