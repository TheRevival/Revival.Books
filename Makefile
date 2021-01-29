# Project variables

PROJECT_NAME ?= Revival.Books

.PHONY: migrations db hello

migrations:
	cd ./Revival.Books.Data && dotnet ef --startup-project ../Revival.Books.Web/ migrations add $(mname) && cd ..
db:
	cd ./Revival.Books.Data && dotnet ef --startup-project ../Revival.Books.Web database update && cd ..
hello:
	echo 'test command to check is makefile works correct'