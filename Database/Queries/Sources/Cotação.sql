USE PJ_EVOL_2013
GO

-- ========================================================================
-- Quotation 
-- First Date:04/01/2016
-- Frequency: Every Day 09:00:00 AM
-- About: Cotações Por Cliente 
-- ========================================================================

SELECT

	   [cdcliente] AS CodCli
	  ,[Cotação] AS QuotationCode
	  ,CASE WHEN [Comodato] = 1 THEN 'Sim'
	   ELSE  'Não' END Comodato
	  ,CASE WHEN [Documentação_Invalida] = 1 THEN 'Sim'
	   ELSE  'Não' END InvalidDocumentation
	  ,CASE WHEN [NDESIGNADA] = 1 THEN 'Sim'
	   ELSE  'Não' END Designated
      ,[Criado em] AS CreatedDate

FROM [PJ_EVOL_2013].[dbo].[COT_ATV]
ORDER BY 1, 6