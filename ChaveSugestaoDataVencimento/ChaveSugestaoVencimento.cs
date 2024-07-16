//código omitido

string dataSugerida = UtilizaSugestaoDeDataDeVencimento();
            if (!string.IsNullOrEmpty(dataSugerida))
            {
                txtlDataVencimento.Text = dataSugerida;
                UpdatePanel16.Update();
            }

//código omitido

private string UtilizaSugestaoDeDataDeVencimento()
        {
            Configuracao UsaChave = new ConfiguracaoBLL().SelectByChave("usa_sugestao_data_vencimento");
            string datasDaChave = UsaChave.Valor;
            if (string.IsNullOrEmpty(datasDaChave))
            {
                return "";
            }
            else
            {
                List<string> datasArray = datasDaChave.Split(',').Select(data => data.Trim()).ToList();
                List<int> datasSeparadas = datasArray.Select(int.Parse).ToList();
                string dataEmissaoSelecionada = txtDataEmissao.Text;
                CondicaoPagamento condicaoDePagamentoSelecionada = new CondicaoPagamentoBLL().SelectById(Convert.ToInt32(ddlPagamento.SelectedValue));
                DateTime dataEmissao = new DateTime();
                if (DateTime.TryParse(dataEmissaoSelecionada, out dataEmissao))
                {
                    int prazo = condicaoDePagamentoSelecionada.Prazo;
                    DateTime dataComPrazo = dataEmissao.AddDays(prazo);
                    datasSeparadas.Sort();
                    int diaSugerido = datasSeparadas.FirstOrDefault(dia => dia >= dataComPrazo.Day);
                    if (diaSugerido == 0)
                    {
                        diaSugerido = datasSeparadas.First();
                        DateTime mes = dataComPrazo.AddMonths(1);
                        DateTime dataSugeridaComMes = new DateTime(dataComPrazo.Year, mes.Month, diaSugerido);
                        return dataSugeridaComMes.ToString("dd/MM/yyyy");
                    }
                    DateTime dataSugerida = new DateTime(dataComPrazo.Year, dataComPrazo.Month, diaSugerido);
                    return dataSugerida.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "";
                }
            }
        }