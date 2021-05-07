using System;

namespace GestaoEquipamentos.ConsoleApp
{

    public class ControladorBase
    {
        public const int CAPACIDADE_REGISTROS = 100;
        public object[] registros = null;

        public ControladorBase()
        {
            registros = new object[CAPACIDADE_REGISTROS];
        }

        public bool ExcluirRegistro(object obj)
        {
            bool conseguiuExcluir = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    registros[i] = null;
                    conseguiuExcluir = true;
                    break;
                }
            }
            return conseguiuExcluir;
        }

        protected object SelecionarRegistroPorId(object id)
        {
            object ObjAux = null;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i].Equals(id))
                {
                    ObjAux = registros[i];
                    break;
                    
                }
            }
            return ObjAux;
        }

        public object[] SelecionarTodosRegistros()
        {
            object[] objAux = new object[QtdRegistrosCasdastrados(registros)];

            int i = 0;

            foreach (object registro in registros)
            {
                if (registro != null)
                    objAux[i++] = registro;
            }
            return objAux;
        }

        private int QtdRegistrosCasdastrados(object[] registros)
        {
            int numeroCadastrados = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    numeroCadastrados++;
                }
            }

            return numeroCadastrados;
        }

        protected int ObterPosicaoParaRegistros(object obj, int idSelecionado)
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                //retorna uma posição para inserir equipamento
                if (idSelecionado == 0 && registros[i] == null)
                {
                    posicao = i;
                    break;
                }
                //retorna uma posição de um equipamento existente
                else if (registros[i] != null && registros[i].Equals(obj)) //editando...
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
    }
}
