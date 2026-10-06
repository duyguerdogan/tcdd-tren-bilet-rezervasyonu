param([string]$MSBuildPath, [string]$WindowsSdkPath)
$ErrorActionPreference = 'Stop'
$repo = Split-Path $PSScriptRoot -Parent
if (-not $MSBuildPath) {
    $vswhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio/Installer/vswhere.exe'
    if (Test-Path -LiteralPath $vswhere) {
        $MSBuildPath = & $vswhere -latest -products '*' -requires Microsoft.Component.MSBuild -find 'MSBuild\**\Bin\MSBuild.exe' | Select-Object -First 1
    }
}
if (-not $MSBuildPath) { throw 'MSBuild bulunamadı. Visual Studio Developer PowerShell kullanın veya -MSBuildPath belirtin.' }
$buildArgs = @((Join-Path $repo 'WindowsFormsApp1.sln'), '/t:Rebuild', '/p:Configuration=Release', '/verbosity:minimal', '/nologo')
if ($WindowsSdkPath) { $buildArgs += "/p:TargetPlatformSdkPath=$WindowsSdkPath"; $buildArgs += '/p:TargetPlatformDisplayName=Windows' }
& $MSBuildPath @buildArgs
if ($LASTEXITCODE -ne 0) { throw 'Derleme başarısız.' }
$compiler = Join-Path (Split-Path $MSBuildPath -Parent) 'Roslyn/csc.exe'
$output = Join-Path $repo 'WindowsFormsApp1/bin/Release'
& $compiler /nologo /target:exe "/out:$output/RegressionTests.exe" "/reference:$output/WindowsFormsApp1.exe" (Join-Path $PSScriptRoot 'RegressionTests.cs')
if ($LASTEXITCODE -ne 0) { throw 'Test derlemesi başarısız.' }
$testData = Join-Path $repo ('TestResults/' + [Guid]::NewGuid().ToString('N'))
& (Join-Path $output 'RegressionTests.exe') $testData
if ($LASTEXITCODE -ne 0) { throw 'Testler başarısız.' }
Write-Output "Test verileri ve arayüz görüntüleri: $testData"
