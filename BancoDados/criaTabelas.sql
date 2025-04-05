/*
   banco de dados Roma Embalagens
   script para criacao das  tabelas 
   Gilberto Anderson jan 2025

   servidor:       sql8010.site4now.net
   banco de dados: db_a49cbe_roma
   user:           db_a49cbe_roma_admin
   pass:           Roma@202501
*/




BEGIN-- .......................... apagando todas as tabelas

	
-- .................................................................... 13 tblOrdemServicoItem
	if Exists(Select name from sysobjects where name='tblOrdemServicoItem')Begin 
		drop table dbo.tblOrdemServicoItem
	End
	
-- .................................................................... 12 tblOrdemServico
	if Exists(Select name from sysobjects where name='tblOrdemServico')Begin 
		drop table dbo.tblOrdemServico
	End


-- .................................................................... 11 tblOrcamentoItem
	if Exists(Select name from sysobjects where name='tblOrcamentoItem')Begin 
		drop table dbo.tblOrcamentoItem
	End


-- .................................................................... 10 tblOrcamento
	if Exists(Select name from sysobjects where name='tblOrcamento')Begin 
		drop table dbo.tblOrcamento
	End
	
-- .................................................................... 09 tblProdutoItem
	if Exists(Select name from sysobjects where name='tblProdutoItem')Begin 
		drop table dbo.tblProdutoItem
	End
	
-- .................................................................... 08 tblProduto
	if Exists(Select name from sysobjects where name='tblProduto')Begin 
		drop table dbo.tblProduto
	End
	
-- .................................................................... 07 tblItem
	if Exists(Select name from sysobjects where name='tblItem')Begin 
		drop table dbo.tblItem
	End
	
-- .................................................................... 06 tblContato
	if Exists(Select name from sysobjects where name='tblContato')Begin 
		drop table dbo.tblContato
	End
	
-- .................................................................... 05 tblCliente
	if Exists(Select name from sysobjects where name='tblCliente')Begin 
		drop table dbo.tblCliente
	End
	
-- .................................................................... 04 tblUsuarios
	if Exists(Select name from sysobjects where name='tblUsuario')Begin 
		drop table dbo.tblUsuario
	End

-- .................................................................... 03 tblDominios
	if Exists(Select name from sysobjects where name='tblDominios')Begin 
		drop table dbo.tblDominios
	End	
	
-- .................................................................... 02 tblPerfil
	if Exists(Select name from sysobjects where name='tblPerfil')Begin 
		drop table dbo.tblPerfil
	End

-- .................................................................... 01 tblStatus
	if Exists(Select name from sysobjects where name='tblStatus')Begin 
	 	drop table dbo.tblStatus
	End	

END



--........................... criando as tabelas
BEGIN  


-- .................................................................... 01 tblStatus
begin	
	if Exists(Select name from sysobjects where name='tblStatus')Begin 
		drop table dbo.tblStatus
	End	

  	CREATE TABLE dbo.tblStatus(
		[idStatus]		int 	IDENTITY(1,1) NOT NULL,
		[Objeto]		VARCHAR(30),
		[Descricao]		VARCHAR(30),

		CONSTRAINT [pk_Status] PRIMARY KEY CLUSTERED 
		(
			[idStatus] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

		
		CREATE INDEX idx_Status
		ON tblStatus ([Descricao]);
	 
/*
	  select * from dbo.tblStatus
		
	*/	
-- .................................................................... 02 tblPerfil	
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('PERFIL','ATIVO')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('PERFIL','INATIVO')

-- .................................................................... 04 tblUsuario	
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('USUARIO','ATIVO')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('USUARIO','INATIVO')	

	
-- .................................................................... 05 tblCliente	
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('CLIENTE','ATIVO')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('CLIENTE','INATIVO')

-- .................................................................... 06 tblContato
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('CONTATO','ATIVO')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('CONTATO','INATIVO')
	
	
-- .................................................................... 07 tblItem	
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ITEM','ATIVO')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ITEM','INATIVO')		
	
-- .................................................................... 08 tblProduto
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('PRODUTO','ATIVO')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('PRODUTO','INATIVO')		
	
-- .................................................................... 08 tblProdutoItem
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('PRODUTOITEM','ATIVO')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('PRODUTOITEM','INATIVO')		
	
-- .................................................................... 10 tblProduto
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORCAMENTO','Elaboracao')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORCAMENTO','Enviado')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORCAMENTO','Aprovado')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORCAMENTO','Produção')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORCAMENTO','Faturado')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORCAMENTO','Entregue')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORCAMENTO','Reprovado')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORCAMENTO','Cancelado')
	
	
-- .................................................................... 12 tblOrdemServico
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORDEMSERVICO','Planejada')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORDEMSERVICO','Fabricação')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('ORDEMSERVICO','Finalizada')
	
	
	
-- .................................................................... 13 tblOrdemServicoItem
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('OSITEM','Planejada')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('OSITEM','Fabricação')
	INSERT INTO tblStatus(Objeto,Descricao)
	VALUES('OSITEM','Finalizada')
	
end

/*
-- .................................................................... 02 tblPerfil
begin		
	if Exists(Select name from sysobjects where name='tblPerfil')Begin 
		drop table dbo.tblPerfil
	End
	
	create table dbo.tblPerfil(
		[idPerfil]		int identity(1,1) not null,
		[Descricao]		varchar(020)      not null,
		[idStatus]		int               not null,
		CONSTRAINT [PK_tblPerfil] PRIMARY KEY CLUSTERED 
		(
			[idPerfil] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

	
	ALTER TABLE dbo.tblPerfil
	ADD CONSTRAINT fk_tblPerfilStatus
	FOREIGN KEY (idStatus)
	REFERENCES tblStatus(idStatus)
	
	-- select * from tblPerfil
	
	insert into tblPerfil(Descricao) values('ADMIN')
	insert into tblPerfil(Descricao) values('PRODUCAO')
	insert into tblPerfil(Descricao) values('COMERCIAL')
	insert into tblPerfil(Descricao) values('PCP')

end
*/

-- .................................................................... 03 tblDominios
begin	 
	
	if Exists(Select name from sysobjects where name='tblDominios')Begin 
		drop table dbo.tblDominios
	End	
	
  	CREATE TABLE dbo.tblDominios(
		idDominio		int 	IDENTITY(1,1) NOT NULL,
		Objeto			VARCHAR(20),
		Codigo			VARCHAR(3),
		Descricao		VARCHAR(50),

		CONSTRAINT [pk_Dominio] PRIMARY KEY CLUSTERED 
		(
			idDominio ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]


		
		CREATE INDEX idx_Dominio
		ON tblDominios ([Descricao]);
		
	-- select * from tblDominios
    
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('TIPOITEM','MT','Material')
		
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('TIPOITEM','SV','Serviço')
		
		
		
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('UNIDADE','FL','Folha')
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('UNIDADE','KG','Kilo')
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('UNIDADE','PC','Peça')
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('UNIDADE','HR','Horas')

	
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('FORMAPAGTO','AV','A VISTA')
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('FORMAPAGTO','BL','BOLETO')
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('FORMAPAGTO','CR','CREDITO')
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('FORMAPAGTO','DB','DEBITO EM CONTA')
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('FORMAPAGTO','PX','PIX')
	
	
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('COR','41','4 X 1')
	INSERT INTO tblDominios(Objeto,Codigo,Descricao)
	VALUES('COR','21','2 X 1')
	
end


-- .................................................................... 04 tblUsuarios
begin	 
 
	
	if Exists(Select name from sysobjects where name='tblUsuario')Begin 
		drop table dbo.tblUsuario
	End
	
	create table dbo.tblUsuario(
		[idUsuario]			int identity(1,1) not null,
		[Nome]				varchar(240)      not null,
		[Email]				varchar(240)      not null,
		[Senha]				varchar(020)      not null,
		[Celular]			varchar(025)      not null,
		[dtNascimento]		date,
		[idStatus]			int              not null,	
		[idPerfil]			int              not null,		
		[dtAtualizacao]		datetime DEFAULT getdate(), 
		CONSTRAINT [PK_tblUsuario] PRIMARY KEY CLUSTERED 
		(
			[idUsuario] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]
	

		--CREATE UNIQUE INDEX idx_Usuario
		--ON tblUsuario ([Nome], [Email]);

		CREATE UNIQUE INDEX idx_UsuarioEmail
		ON tblUsuario ([Email]);

		
		CREATE UNIQUE INDEX idx_UsuarioCPF
		ON tblUsuario ([CPF_CNPJ]);
				
		ALTER TABLE dbo.tblUsuario
		ADD CONSTRAINT fk_tblUsuarioStatus
		FOREIGN KEY (idStatus)
		REFERENCES tblStatus(idStatus)
		
		ALTER TABLE dbo.tblUsuario
		ADD CONSTRAINT fk_tblUsuarioPerfil
		FOREIGN KEY (idPerfil)
		REFERENCES tblPerfil(idPerfil)
		
		
		
		/*
		 select * from  tblUsuario
		


		insert into tblUsuario(Email,  Nome, Senha, Celular, dtNascimento, idStatus, idPerfil)
		values('gilberto.anderson@gmail.com', 'Gilberto Anderson','segredo','1198988989','09-26-1962',
				(select idStatus from tblStatus where Objeto = 'USUARIO' and Descricao = 'ATIVO'),
				(select idPerfil from tblPerfil where Descricao = 'ADMIN'))
				
				
				
		insert into tblUsuario(Email,  Nome, Senha, Celular, dtNascimento, idStatus, idPerfil)
		values('robson.vasquez@gmail.com', 'Robson Vasquez','segredo','1198988989','09-26-1962',
				(select idStatus from tblStatus where Objeto = 'USUARIO' and Descricao = 'ATIVO'),
				(select idPerfil from tblPerfil where Descricao = 'PRODUCAO'))
		
		insert into tblUsuario(Email,  Nome, Senha, Celular, dtNascimento, idStatus, idPerfil)
		values('Guilherme Antunes@gmail.com', 'Guilherme Antunes','segredo','1198988989','09-26-1962',
				(select idStatus from tblStatus where Objeto = 'USUARIO' and Descricao = 'ATIVO'),
				(select idPerfil from tblPerfil where Descricao = 'PRODUCAO'))
				
		*/

		  
end


-- .................................................................... 05 tblCliente
begin		
	if Exists(Select name from sysobjects where name='tblCliente')Begin 
		drop table dbo.tblCliente
	End
	
	create table dbo.tblCliente(
		[idCliente]		int identity(1,1)     not null,
		[Nome]			varchar(120)          not null,
		[Endereco]		varchar(120)          null, 
		[Bairro]		varchar(120)          null,
		[Cidade]		varchar(120)          null,
		[UF]		    varchar(2)            null,
		[CEP]		    varchar(9)            null,
		[CNPJ]		    varchar(14)            null,
		[Telefone]		varchar(120)          null,
		[idStatus]		int                   not null,
		CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED 
		(
			[idCliente] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

	
	ALTER TABLE dbo.tblCliente
	ADD CONSTRAINT fk_tblClienteStatus
	FOREIGN KEY (idStatus)
	REFERENCES tblStatus(idStatus)
	
	ALTER TABLE dbo.tblCliente
	alter column  [CNPJ] varchar(14)  null
	
	/*
	  select * from  tblCliente  

		insert into tblCliente( Nome, Endereco, Bairro, Cidade, UF, CEP, CnPj, Telefone, idStatus)
		values('Padaria Rei do Pão', 'Av. Portugal, 535','Vila Bastos','Santo Andre', 'SP','09230-590','00000000000105','1198988989',
				(select idStatus from tblStatus where Objeto = 'CLIENTE' and Descricao = 'ATIVO'))
				
				
				
		insert into tblCliente( Nome, Endereco, Bairro, Cidade, UF, CEP, CnPj, Telefone, idStatus)
		values('Padaria Portugal', 'Av. Portugal, 894','Jardim Bela Vista','Santo Andre', 'SP','09230-590','00000000000105','1198988989',
				(select idStatus from tblStatus where Objeto = 'CLIENTE' and Descricao = 'ATIVO'))
				
				
		insert into tblCliente( Nome, Endereco, Bairro, Cidade, UF, CEP, CnPj, Telefone, idStatus)
		values('Padaria Bella Vitória', ' R. Tuiuti, 39','Jardim Bela Vista','Santo Andre', 'SP','09041-420','00000000000105','1198988989',
				(select idStatus from tblStatus where Objeto = 'CLIENTE' and Descricao = 'ATIVO'))
				
				
		insert into tblCliente( Nome, Endereco, Bairro, Cidade, UF, CEP, CnPj, Telefone, idStatus)
		values('Panificadora Lindo Pão', 'R. Votorantim, 311','Barcelona','São Caetano do Sul', 'SP','09550-300','00000000000105','1198988989',
				(select idStatus from tblStatus where Objeto = 'CLIENTE' and Descricao = 'ATIVO'))
					
		insert into tblCliente( Nome, Endereco, Bairro, Cidade, UF, CEP, CnPj, Telefone, idStatus)
		values('Padaria Monte Carlo', ' R. São Paulo, 1890','Santa Paula','São Caetano do Sul', 'SP','09550-300','00000000000105','1198988989',
				(select idStatus from tblStatus where Objeto = 'CLIENTE' and Descricao = 'ATIVO'))
				
				
	*/			
		
end


-- .................................................................... 06 tblContato
begin		
	if Exists(Select name from sysobjects where name='tblContato')Begin 
		drop table dbo.tblContato
	End
	
	create table dbo.tblContato(
		[idContato]		int identity(1,1)     not null,
		[idCliente]		int      			  not null,
		[Nome]			varchar(120)          not null,
		[Celular]		varchar(12)           null,
		[Email]		    varchar(120)          null,
		[dtNascimento]		date,
		[idStatus]		int                   not null,
		CONSTRAINT [PK_tblContato] PRIMARY KEY CLUSTERED 
		(
			[idContato] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

	
	ALTER TABLE dbo.tblContato
	ADD CONSTRAINT fk_tblContatoStatus
	FOREIGN KEY (idStatus)
	REFERENCES tblStatus(idStatus)
	
	
	ALTER TABLE dbo.tblContato
	ADD CONSTRAINT fk_tblContatoCliente
	FOREIGN KEY (idCliente)
	REFERENCES tblCliente(idCliente)
	

  /*
		select * from  tblContato
		
		insert into tblContato( Nome, Celular, Email, dtNascimento, idStatus, idCliente)
		values('Paulo Roberto', '11 9999 8989','paulo.roberto@teste.com', '01-15-2001',
				(select idStatus from tblStatus where Objeto = 'CONTATO' and Descricao = 'ATIVO'),
				(select idCliente from tblCliente where Nome = 'Padaria Rei do Pão'))
	*/
end



-- .................................................................... 07 tblItem
begin		
	if Exists(Select name from sysobjects where name='tblItem')Begin 
		drop table dbo.tblItem
	End
	
	create table dbo.tblItem(
		[idItem]		int identity(1,1)     not null,
		[idTipoItem]	int      			  not null,  
		[Nome]			varchar(120)          not null,
		[Formato]		varchar(120)          null,
		[Gramatura]		varchar(120)          null,
		[idUnidade]		int                   not null,
		[Valor]			decimal(18,2),
		[dtAtualizacao]	datetime,
		[idStatus]		int                   not null,
		CONSTRAINT [PK_tblItem] PRIMARY KEY CLUSTERED 
		(
			[idItem] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

	
	ALTER TABLE dbo.tblItem
	ADD CONSTRAINT fk_tblItemStatus
	FOREIGN KEY (idStatus)
	REFERENCES tblStatus(idStatus)
	
	
	ALTER TABLE dbo.tblItem
	ADD CONSTRAINT fk_tblItemUnidade
	FOREIGN KEY (idUnidade)
	REFERENCES tblDominios(idDominio)
	
	ALTER TABLE dbo.tblItem
	ADD CONSTRAINT fk_tblItemTipoItem
	FOREIGN KEY (idTipoItem)
	REFERENCES tblDominios(idDominio)
	
	ALTER TABLE dbo.tblItem
	drop CONSTRAINT fk_tblItemTipoItem
	
	ALTER TABLE dbo.tblItem
	drop CONSTRAINT fk_tblItemUnidade
	
	/*
	
		select * from  tblItem

		insert into tblItem( Nome, Formato, Gramatura, Valor, dtAtualizacao, idTipoItem, idUnidade, idStatus)
		values('Papel DPX', '38 x 73','210 g/m2', 105.23, '01-15-2001',
				(select idDominio from tblDominios where Objeto= 'TIPOITEM' and Codigo = 'MT'),
				(select idDominio from tblDominios where Objeto= 'UNIDADE' and Codigo = 'FL'),
				(select idStatus from tblStatus where Objeto = 'ITEM' and Descricao = 'ATIVO'))
				
		
		insert into tblItem( Nome, Formato, Gramatura, Valor, dtAtualizacao, idTipoItem, idUnidade, idStatus)
		values('Guilhotina', '','', 100.00, '01-15-2001',
				(select idDominio from tblDominios where Objeto= 'TIPOITEM' and Codigo = 'SV'),
				(select idDominio from tblDominios where Objeto= 'UNIDADE' and Codigo = 'HR'),
				(select idStatus from tblStatus where Objeto = 'ITEM' and Descricao = 'ATIVO'))
				
				update tblItem
				set idtipoItem = 1 
				where idItem = 6	
									
	*/
end



-- .................................................................... 08 tblProduto
begin		
	if Exists(Select name from sysobjects where name='tblProduto')Begin 
		drop table dbo.tblProduto
	End
	
	create table dbo.tblProduto(
		[idProduto]		int identity(1,1)     not null,
		[Nome]			varchar(120)          not null, 
		[idUnidade]		int                   not null,
		[Valor]			decimal(18,2),
		[Observacao]	varchar(max),
		[dtAtualizacao]	datetime,
		[idStatus]		int                   not null,
		
		CONSTRAINT [PK_tblProduto] PRIMARY KEY CLUSTERED 
		(
			[idProduto] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

		
		
		
	ALTER TABLE dbo.tblProduto
	ADD CONSTRAINT fk_tblProdutoStatus
	FOREIGN KEY (idStatus)
	REFERENCES tblStatus(idStatus)
		
	ALTER TABLE dbo.tblProduto
	ADD CONSTRAINT fk_tblProdutoUnidade
	FOREIGN KEY (idUnidade)
	REFERENCES tblDominios(idDominio)
	
	
	/*
	
		select * from  tblProduto

		insert into tblProduto( Nome, Observacao, Valor, dtAtualizacao, idUnidade, idStatus)
		values('Caixa Pizza 25 Quadrada', 'observaçao', 105.23, '01-15-2001',
				(select idDominio from tblDominios where Objeto= 'UNIDADE' and Codigo = 'PC'),
				(select idStatus from tblStatus where Objeto = 'PRODUTO' and Descricao = 'ATIVO'))
						
										
	*/
end




-- .................................................................... 09 tblProdutoItem
begin		
	if Exists(Select name from sysobjects where name='tblProdutoItem')Begin 
		drop table dbo.tblProdutoItem
	End
	
	create table dbo.tblProdutoItem(
		[idProdutoItem]		int identity(1,1)     not null,
		[idProduto]			int      			  not null,   
		[idItem]			int      			  not null, 
		[Quantidade]		decimal(18,2),
		[Valor]				decimal(18,2),
		[Observacao]		varchar(max),
		[idStatus]			int                   not null,
		CONSTRAINT [PK_tblProdutoItem] PRIMARY KEY CLUSTERED 
		(
			[idProdutoItem] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

		
	ALTER TABLE dbo.tblProdutoItem
	ADD CONSTRAINT fk_tblProdutoItemProduto
	FOREIGN KEY (idProduto)
	REFERENCES tblProduto(idProduto)
	
	ALTER TABLE dbo.tblProdutoItem
	ADD CONSTRAINT fk_tblProdutoItemItem
	FOREIGN KEY (idItem)
	REFERENCES tblItem(idItem)
	
	
		
	ALTER TABLE dbo.tblProdutoItem
	ADD CONSTRAINT fk_tblProdutoItemStatus
	FOREIGN KEY (idStatus)
	REFERENCES tblStatus(idStatus)
	
	
	/*
	
		select * from  tblItem
		select * from  tblProdutoItem where idProduto = 5
		delete from  tblProdutoItem
		update tblProdutoItem set quantidade = 1
		insert into tblProdutoItem( idProduto, idItem, idStatus, Quantidade, Observacao,  valor)
		values( (select idProduto from tblProduto where Nome = 'Caixa Pizza 25 Quadrada' ),
				(select idItem    from tblItem    where Nome = 'Papel DPX' ),
				(select idStatus from tblStatus where Objeto = 'PRODUTOITEM' and Descricao = 'ATIVO'),
                 500, 'observacao', 10)
		
						
										
	*/
end



-- .................................................................... 10 tblOrcamento
begin		
	if Exists(Select name from sysobjects where name='tblOrcamento')Begin 
		drop table dbo.tblOrcamento
	End
	
	create table dbo.tblOrcamento(
		[idOrcamento]	int identity(1,1)     not null,
		[idContato]		int                   not null,
		[idCliente]		int      			  not null,
		[idUsuario]		int      			  not null, 
		[idFormaPagto]	int      			  not null,
		[idStatus]		int                   not null,
		[nrOrcamento]	varchar(9),
		[dtCriacao]		datetime,
		[dtEnvio]		datetime,
		[dtValidade]	datetime,
		[dtEntrega]		datetime,
		
		[ValorOrcado]	decimal(18,2),
		[ValorDesconto]	decimal(18,2),
		[ValorFinal]	decimal(18,2),
		
		[Observacao]	varchar(max) ,
		
		CONSTRAINT [PK_tblOrcamento] PRIMARY KEY CLUSTERED 
		(
			[idOrcamento] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

	
	ALTER TABLE dbo.tblOrcamento
	ADD CONSTRAINT fk_tblOrcamentoStatus
	FOREIGN KEY (idStatus)
	REFERENCES tblStatus(idStatus)
	
	ALTER TABLE dbo.tblOrcamento 
	ADD CONSTRAINT fk_tblOrcamentoCliente
	FOREIGN KEY (idCliente)
	REFERENCES tblCliente(idCliente)
	
	ALTER TABLE dbo.tblOrcamento 
	ADD CONSTRAINT fk_tblOrcamentoContato
	FOREIGN KEY (idContato)
	REFERENCES tblClontato(idContato)
	
	
	ALTER TABLE dbo.tblOrcamento 
	ADD CONSTRAINT fk_tblOrcamentoUsuario
	FOREIGN KEY (idUsuario)
	REFERENCES tblUsuario(idUsuario)
	
	ALTER TABLE dbo.tblOrcamento 
	ADD CONSTRAINT fk_tblOrcamentoFormaPagto
	FOREIGN KEY (idUFormaPagto)
	REFERENCES tblDominio(idDominio)
	
	/*    
	 
	 select * from  tblOrcamento orc
	 inner join tblCliente cli on orc.idcliente = cli.idcliente
	 
	 
	 insert into tblOrcamento( idUsuario,idContato, idCliente, idFormaPagto, idStatus, 
	                           nrOrcamento, dtCriacao, ValorOrcado, ValorDesconto, ValorFinal, Observacao )
	                 values(
	                 
				             (select idUsuario from tblUsuario  where Nome   = 'Gilberto Anderson'),
				             (select idContato from tblContato  where Nome   = 'Paulo Roberto'),
				             (select idCliente from tblCliente  where Nome   = 'Padaria Rei do Pão'),
				             (select idDominio from tblDominios where Objeto = 'FORMAPAGTO' and Codigo = '00'),
				             (select idStatus  from tblStatus   where Objeto = 'ORCAMENTO' and Descricao = 'Elaboracao'),
	                        '250206001', '02-06-2025',  200.00, 50.00, 150.00, 'observacao' )
	 
	 
	 
	 
	 */

	
end


-- .................................................................... 11 tblOrcamentoItem
begin		
	if Exists(Select name from sysobjects where name='tblOrcamentoItem')Begin 
		drop table dbo.tblOrcamentoItem
	End
	
	create table dbo.tblOrcamentoItem(
		[idOrcamentoItem]	int identity(1,1)     not null,
		[idOrcamento]		int                   not null,   
		[idProduto]			int      			  not null,
		[idUnidade]			int      			  not null,
		[Nome]		    	varchar(120)          not null, 
		[Sequencial]		int      			  not null, 
		[Quantidade]		decimal(18,2)    	  not null,
		[ValorUnitario]		int                   not null,
		[Observacao]		varchar(max),
		
		CONSTRAINT [PK_tblOrcamentoItem] PRIMARY KEY CLUSTERED 
		(
			[idOrcamentoItem] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

	
	
	ALTER TABLE dbo.tblOrcamentoItem 
	ADD CONSTRAINT fk_tblOrcamentoItemOrcamento
	FOREIGN KEY (idOrcamento)
	REFERENCES tblOrcamento(idOrcamento)
	
	
	ALTER TABLE dbo.tblOrcamentoItem 
	ADD CONSTRAINT fk_tblOrcamentoItemProduto
	FOREIGN KEY (idProduto)
	REFERENCES tblOrcamento(idProduto)
	
	
	/*
		select * from  tblOrcamentoItem


	     insert into tblOrcamentoItem( idOrcamento, idProduto, Sequencial, Quantidade, ValorUnitario, Observacao, idUnidade)
	                 values(
							 (select idOrcamento from tblOrcamento  where nrOrcamento   =  '250206001'),
				             (select idProduto   from tblProduto    where Nome   = 'Caixa Pizza 25 Quadrada'),
	                           2, 100, 3.00, 'observacao',1)


	*/
	
	
	
	
	
end


-- .................................................................... 12 tblOrdemServico
begin		
	if Exists(Select name from sysobjects where name='tblOrdemServico')Begin 
		drop table dbo.tblOrdemServico
	End
	
	create table dbo.tblOrdemServico(
		[idOrdemServico] int identity(1,1)     not null,
		[idCliente]		 int      			  not null,
		[idUsuario]		 int      			  not null,  
		[idStatus]		 int                   not null,
		[nrOrdem]	     varchar(11),
		[dtCriacao]		 datetime,
		[dtEntrega]		 datetime,
		[Quantidade]	 int,
		[idCor]			 int,
		[Observacao]	 varchar(max) ,
		
		CONSTRAINT [PK_tblOrdemServico] PRIMARY KEY CLUSTERED 
		(
			[idOrdemServico] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

	
	ALTER TABLE dbo.tblOrdemServico
	ADD CONSTRAINT fk_tblOrdemServicoStatus
	FOREIGN KEY (idStatus)
	REFERENCES tblStatus(idStatus)
	
	ALTER TABLE dbo.tblOrdemServico 
	ADD CONSTRAINT fk_tblOrdemServicoCliente
	FOREIGN KEY (idCliente)
	REFERENCES tblCliente(idCliente)
	
	
	ALTER TABLE dbo.tblOrdemServico 
	ADD CONSTRAINT fk_tblOrdemServicoUsuario
	FOREIGN KEY (idUsuario)
	REFERENCES tblUsuario(idUsuario)
	
	
	/*    
	 
	 select * from  tblOrdemServico
	 
	 insert into tblOrdemServico( idUsuario, idCliente,  idStatus, idCor, nrOrdem, dtCriacao, dtEntrega, Quantidade,  Observacao)
	                 values(
							 (select idUsuario from tblUsuario  where Nome   = 'Gilberto Anderson'),
				             (select idCliente from tblCliente  where Nome   = 'Padaria Rei do Pão'),
				             (select idStatus  from tblStatus   where Objeto = 'ORDEMSERVICO' and Descricao = 'Planejada'), 
				             (select idDominio from tblDominios where Objeto = 'COR' and Codigo = '41'),
	                        'OS250206001', '02-06-2025', '02-28-2025', 100,  'observacao' )
	 
	 
	 
	 */

	
end


-- .................................................................... 13 tblOrdemServicoItem
begin		
	if Exists(Select name from sysobjects where name='tblOrdemServicoItem')Begin 
		drop table dbo.tblOrdemServicoItem
	End
	
	create table dbo.tblOrdemServicoItem(
		[idOrdemServicoItem]	int identity(1,1)     not null,
		[idOrdemServico]		int                   not null,   
		[idItem]		   	    int      			  not null,
		[idStatus]		        int                   not null,
		[Sequencial]		    int      			  not null, 
		[Quantidade]		    decimal(18,2)    	  not null, 
		[idResponsavel]		    int                   not null,
		[dtInicio]		    	datetime              null,
		[dtTermino]		        datetime              null,
		[Observacao]		    varchar(max),
		
		CONSTRAINT [PK_tblOrdemServicoItem] PRIMARY KEY CLUSTERED 
		(
			[idOrdemServicoItem] ASC
		)WITH (
				PAD_INDEX  = OFF, 
				STATISTICS_NORECOMPUTE  = OFF, 
				IGNORE_DUP_KEY = OFF,	
				ALLOW_ROW_LOCKS  = ON, 
				ALLOW_PAGE_LOCKS  = ON) 
				ON [PRIMARY]
		) ON [PRIMARY]

	
	
	ALTER TABLE dbo.tblOrdemServicoItem 
	ADD CONSTRAINT fk_tblOrdemServicoItemOrdemServico
	FOREIGN KEY (idOrdemServico)
	REFERENCES tblOrdemServico(idOrdemServico)
	
	
	ALTER TABLE dbo.tblOrdemServicoItem 
	ADD CONSTRAINT fk_tblOrdemServicoItemItem
	FOREIGN KEY (idItem)
	REFERENCES tblidItem(idItem)
	
	
	ALTER TABLE dbo.tblOrdemServicoItem 
	ADD CONSTRAINT fk_tblOrdemServicoItemStatus
	FOREIGN KEY (idStatus)
	REFERENCES tblStatus(idStatus)
	
	
	/*
		select * from  tblOrdemServicoItem


	     insert into tblOrdemServicoItem( idOrdemServico, idItem, idStatus, idResponsavel, Sequencial, Quantidade, dtInicio, dtTermino, Observacao )
	                 values(
							 (select idOrdemServico from tblOrdemServico  where nrOrdem   =  'OS250206001'),
				             (select idItem        from tblItem           where Nome   = 'Papel DPX'),
				             (select idStatus      from tblStatus         where Objeto = 'OSITEM' and Descricao = 'Planejada'), 
				             (select idUsuario     from tblUsuario        where Nome = 'Guilherme Antunes'),
	                           1, 500, '02-06-2025', '02-06-2025', 'observacao')

	     insert into tblOrdemServicoItem( idOrdemServico, idItem, idStatus, idResponsavel, Sequencial, Quantidade, dtInicio, dtTermino, Observacao )
	                 values(
							 (select idOrdemServico from tblOrdemServico  where nrOrdem   =  'OS250206001'),
				             (select idItem        from tblItem           where Nome   = 'Guilhotina'),
				             (select idStatus      from tblStatus         where Objeto = 'OSITEM' and Descricao = 'Planejada'), 
				             (select idUsuario     from tblUsuario        where Nome = 'Robson Vasquez'),
	                           1, 500, '02-06-2025', null, 'observacao')

	   

	*/
	
	
	
	
	
end




