$module = 'DiffCode.Validating.Interfaces'


dotnet restore
dotnet pack -c Release -o $module\bin\Release\publish
dotnet nuget push $module\bin\Release\publish\$module.*.* --source https://www.diff.me:12989/nuget/NuGetPrivate/ --api-key $ENV:ProGetPersonalAdminApiKey --skip-duplicate