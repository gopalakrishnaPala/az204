<style>
    pre {
        font-size: 24px; 
    }

    .comment {
        color: green;
    }
</style>

# Run the following command from PowerShell to determine your PowerShell version

<pre>
$PSVersionTable.PSVersion
</pre>
<br />

# Determine if you have the AzureRM PowerShell module installed:
<pre>
Get-Module -Name AzureRM -ListAvailable
</pre>
<br />

# Use the Install-Module cmdlet to install the Az PowerShell module:
<pre>
Install-Module -Name Az -Repository PSGallery -Force
</pre>
<br />

# Use Update-Module to update to the latest version of the Az PowerShell module:

<pre>
Update-Module -Name Az -Force
</pre>
<br />
