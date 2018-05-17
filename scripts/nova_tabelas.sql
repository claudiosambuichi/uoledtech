CREATE TABLE [TesteSeusConhecimentos].[CompanyData](
	[IdCompany] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[StreetAdress] [varchar](150) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[ZipCode] [varchar](10) NOT NULL,
	[CompanyActivity] [varchar](50) NOT NULL)
  
CREATE TABLE [TesteSeusConhecimentos].[RelationshipData](
	[IdRelationship] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	FOREIGN KEY (UserId) REFERENCES TesteSeusConhecimentos.UserData(IdUser),
	FOREIGN KEY (CompanyId) REFERENCES TesteSeusConhecimentos.CompanyData(IdCompany));

ALTER TABLE [TesteSeusConhecimentos].[CompanyData]
ADD CONSTRAINT PK_Company PRIMARY KEY (IdCompany);

ALTER TABLE [TesteSeusConhecimentos].[RelationshipData]
ADD CONSTRAINT PK_Relationship PRIMARY KEY (IdRelationship);