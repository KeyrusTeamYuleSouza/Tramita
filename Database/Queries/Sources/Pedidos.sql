USE PJ_EVOL_2013
GO

-- ========================================================================
-- Pedidos
-- First Date:22/04/2010
-- Frequency: Every Day 09:00:00 AM
-- About: Pedidos Gerados Por Cliente 
-- ========================================================================

SELECT
	   [numero_pedido] AS PedidoNumero
      ,[status_pedido] AS PedidoStatus
      ,[Agrupador] AS Agrupador
      ,[Status_Conclusao] AS StatusConclusao
      ,[TipoPed] AS TipoPedido
      ,[revisao] AS Revisao
      ,[dt_inicio] AS DataInicio
      ,[dt_ult_atualizacao] AS DataUltimaAtualizacao
      ,[dt_vencimento] AS DataVencimento
      ,[cpf_cnpj] AS CNPJCPF
      ,[cdcliente] AS CodigoCliente
      ,[qtd_parcelas] AS QtdParcelas
      ,[QtdeLinhas] AS QtdLinhas
      ,[QtdeAlta] AS QtdAlta
      ,[QtdeTroca] AS QtdTroca
      ,[QtdePortab] AS QtdPortabilidade
      ,[QtdeVirtual] AS QtdVirtual
      ,[QtdeBackup] AS QtdBackup
      ,[QtdeLinhasPortabJanela] AS QtdLinhasPortabJanela
      ,[QtdePTT] AS QtdPTT
      ,[QtdeM2M] AS QtdM2M
      ,[QtdeSIM] AS QtdSIM
      ,[QtdeDados] AS QtdDados
      ,[QtdeVoz] AS QtdVoz
      ,[QtdePDA] AS QtdPDA
      ,[QtdeModemRouter] AS QtdModemRouter
      ,[numero_atividade_geradora] AS NumeroAtividadeGerador
      ,[Id_Demanda] AS DemandaID
      ,[Flag_DiasCriacao] AS FlagDiasCriacao
      ,[Flag_DiasUltAtualiz] AS FlagDiasAtualizacao
      ,[Flag_AgingCriacao] AS FlagAgingCriacao
      ,[Flag_AgingAtualiza] AS FlagAgingAtualizacao
      ,[Flag_AgingCriacao2] AS FlagAgingCriacaoII
      ,[Flag_SLA_Backlog] AS FlagSLABacklog
      ,[Flag_SLA_EncerradoOK] AS FlagSLAEncerradoOK
      ,[Flag_Segmento] AS FlagSegmento
      ,[estado_cabecalho] AS EstadoCabecalho
      ,[PRINCIPAL_ACAO_PENDENTE] AS PrincipalAcaoPendente
      ,[DataEntregaPed] AS DataEntregaPedido
      ,[CODEX] AS Codex
      ,[DT_EMISSAO_INTEGRALL] AS DataEmissaoIntegral
      ,[SITUACAO_INTEGRALL] AS SituacaoIntegral
      ,[MOTIVO_INTEGRALL] AS MotivoIntegral
      ,[dt_CRIACAO_INTEGRALL] AS DataCriacaoIntegral
      ,[FlagEntregue] AS FlagEntregue
      ,[CODIGO_ADABAS] AS CodigoAdabas
      ,[Tipo_Venda] AS TipoVenda

FROM [PJ_EVOL_2013].[dbo].[PEDIDOS]


