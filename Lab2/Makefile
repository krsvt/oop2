migration-generate-sql:
	dotnet ef migrations script -o ./script.sql


migration-add:
	dotnet ef migrations add $(shell date +"%Y%m%d%H%M%S")


migration-up:
	dotnet ef database update -v

migration-down:
	pass

migration-remove:
	dotnet ef migrations remove

migration-sync: migration-add migration-up
	echo "done"
