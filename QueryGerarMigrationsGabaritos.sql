SELECT
	CAST(
   'Gabarito g'+cast(NUMERO as varchar) +' = new Gabarito();' + CHAR(13)+CHAR(10)+
	'g'+cast(NUMERO as varchar) +'.Id = '+cast(NUMERO as varchar) +';'+ CHAR(13)+CHAR(10)+
	'g'+cast(NUMERO as varchar) +'.Numero = '+cast(NUMERO as varchar)+';'+ CHAR(13)+CHAR(10)+ 
	'g'+cast(NUMERO as varchar) +'.Descricao = "Gabarito número '+cast(NUMERO as varchar) +'";'+ CHAR(13)+CHAR(10) +
	'g'+cast(NUMERO as varchar) +'.Observacoes = string.Empty;'+ CHAR(13)+CHAR(10) +
	'g'+cast(NUMERO as varchar) +'.Quantidade1 = '+cast(QTD_RANGE_1 as varchar)+';'+ CHAR(13)+CHAR(10) +
	'g'+cast(NUMERO as varchar) +'.Quantidade2 = '+cast(QTD_RANGE_2 as varchar)+';'+ CHAR(13)+CHAR(10) +
	'g'+cast(NUMERO as varchar) +'.Quantidade3 = '+cast(QTD_RANGE_3 as varchar)+';'+ CHAR(13)+CHAR(10) +
	'g'+cast(NUMERO as varchar) +'.Quantidade4 = '+cast(QTD_RANGE_4 as varchar)+';'+ CHAR(13)+CHAR(10) +
	'g'+cast(NUMERO as varchar) +'.Quantidade5 = '+cast(QTD_RANGE_5 as varchar)+';'+ CHAR(13)+CHAR(10) +
	'g'+cast(NUMERO as varchar) +'.Quantidade6 = '+cast(QTD_RANGE_6 as varchar)+';'+ CHAR(13)+CHAR(10) +
	'g'+cast(NUMERO as varchar) +'.Quantidade7 = '+cast(QTD_RANGE_7 as varchar)+';'+ CHAR(13)+CHAR(10) +
	'context.Gabaritos.Add(g'+cast(NUMERO as varchar) +');'+ CHAR(13)+CHAR(10) as xml)
FROM TB_GABARITO