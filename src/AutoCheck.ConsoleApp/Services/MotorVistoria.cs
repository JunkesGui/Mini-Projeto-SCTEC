namespace AutoCheckConsole
{
    public class ResultadoVistoria
    {
        public int PontuacaoObtida { get; set; }
        public int PontuacaoMaximaPossivel { get; set; }
        public double Percentual { get; set; }
        public string Classificacao { get; set; } = string.Empty;
        public string AcaoCorporativa { get; set; } = string.Empty;
        public List<ItemVistoria> ItensCriticos { get; set; } = new List<ItemVistoria>();
        public List<ItemVistoria> ItensAtencao { get; set; } = new List<ItemVistoria>();
        public List<string> Recomendacoes { get; set; } = new List<string>();
    }

    public static class MotorVistoria
    {
        public static int ObterPontuacaoPorStatus(string status)
        {
            int pontos = 0;

            if (status == "Bom")
            {
                pontos = 10;
            }
            else if (status == "Regular")
            {
                pontos = 5;
            }
            else if (status == "Ruim")
            {
                pontos = 0;
            }

            return pontos;
        }

        public static ResultadoVistoria ProcessarVistoria(Veiculo veiculo)
        {
            ResultadoVistoria resultado = new ResultadoVistoria();

            int pontuacaoObtida = 0;
            int totalItens = 0;

            foreach (ItemVistoria item in veiculo.VistoriaRealizada)
            {
                int pontosItem = ObterPontuacaoPorStatus(item.Status);
                pontuacaoObtida += pontosItem;
                totalItens++;

                if (item.Status == "Ruim")
                {
                    resultado.ItensCriticos.Add(item);
                }
                else if (item.Status == "Regular")
                {
                    resultado.ItensAtencao.Add(item);
                }
            }

            int pontuacaoMaximaPossivel = totalItens * 10;

            double percentual = 0;
            if (pontuacaoMaximaPossivel > 0)
            {
                percentual = ((double)pontuacaoObtida / pontuacaoMaximaPossivel) * 100;
            }

            resultado.PontuacaoObtida = pontuacaoObtida;
            resultado.PontuacaoMaximaPossivel = pontuacaoMaximaPossivel;
            resultado.Percentual = percentual;

            if (percentual >= 90)
            {
                resultado.Classificacao = "Aprovado com Excelência";
                resultado.AcaoCorporativa = "Liberado para compra/revenda imediata.";
            }
            else if (percentual >= 60)
            {
                resultado.Classificacao = "Aprovado com Apontamentos";
                resultado.AcaoCorporativa = "Exige desconto na compra para reparos da oficina.";
            }
            else
            {
                resultado.Classificacao = "Reprovado na Vistoria";
                resultado.AcaoCorporativa = "Veículo recusado pela concessionária.";
            }

            resultado.Recomendacoes = GerarRecomendacoes(resultado.ItensCriticos, resultado.ItensAtencao);

            return resultado;
        }

        private static List<string> GerarRecomendacoes(List<ItemVistoria> itensCriticos, List<ItemVistoria> itensAtencao)
        {
            List<string> recomendacoes = new List<string>();

            if (itensCriticos.Count == 0 && itensAtencao.Count == 0)
            {
                recomendacoes.Add("Nenhum reparo necessário. Veículo em plenas condições de uso.");
                return recomendacoes;
            }

            if (itensCriticos.Count > 0)
            {
                recomendacoes.Add("Reparo/troca OBRIGATÓRIO e prioritário nos seguintes itens antes da liberação:");
                for (int i = 0; i < itensCriticos.Count; i++)
                {
                    recomendacoes.Add($"   - {itensCriticos[i].Nome}");
                }
            }

            if (itensAtencao.Count > 0)
            {
                recomendacoes.Add("Revisão preventiva recomendada nos seguintes itens:");
                for (int i = 0; i < itensAtencao.Count; i++)
                {
                    recomendacoes.Add($"   - {itensAtencao[i].Nome}");
                }
            }

            return recomendacoes;
        }
    }
}