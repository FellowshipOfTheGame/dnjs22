1. Baixe e instale: MySQL, Apache, Xampp.
2. Execute o Xampp como administrador e ative, na tela inicial, o MySQL e o Apache.
3. Acesse pelo navegador: localhost/phpmyadmin
4. Crie o banco
	- Foi gerado o arquivo 'exportedDB.sql', mas não tenho certeza de como ele funciona. Se não der certo, tente:
		- As estruturas estão no arquivo dnjs22.sql. Tente executar a primeira linha e, em seguida, clique no ícone no canto esquerdo, referente ao banco criado. Após isso, clique na seção de SQL, no canto superior, e execute a criação das outras tabelas.
		- Outra alternativa é criar o banco manualmente e executar apenas os comandos de criação de tabelas.
		- Se algo der errado, você pode sempre inserir as tabelas manualmente.
5. Abra o diretório do xampp e, em seguida, a pasta htdocs. Crie nela uma pasta chamada 'dnjs22' e insira os arquivos .php.
6. Altere as variáveis, no arquivo Connection.php, de acordo com as suas configurações.