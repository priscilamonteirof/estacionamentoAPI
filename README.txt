Utilizando:
 1. Package EntityFramework
 2. Package Newtonsoft.Json
 3. .Net Frameworkd 4.5

Criado projeto de tests

Autentica��o:
    ~/api/login

Estabelecimento:
	~/api/estabelecimentos
	~/api/estabelecimentos/{id:int}
	~/api/estabelecimentos/save
	~/api/estabelecimentos/delete/{id:int}

Veiculo:
	~/api/veiculos
	~/api/veiculos/{id:int}
	~/api/veiculos/save
	~/api/veiculos/delete/{id:int}

Movimenta��o:
	~/api/movimentacao/ticket/{id:int}
	~/api/movimentacao/placa/{placa}
	~/api/movimentacao/lancar-entrada
	~/api/movimentacao/baixar/{id:int}
	~/api/movimentacao/baixar/{placa}

Relatorios:
	~/api/relatorios/sumario
	~/api/relatorios/sumario-por-hora
