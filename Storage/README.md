# Storage Account Overview

## Azure Storage Account Contains Storage Object
- Blobs
- Files
- Queues
- Tables

## Types of Storage Account
- Standard General Purpose V2
- Premium
    - Block Blobs
    - File Shares (If want to support, Server Message Block (SMB) and NFS file share)
    - Page Blobs

## Create Storage Account
- Using [Azure CLI](./1_CreateAzureStorageAccountCLI.md).

## Types of Blobs
- *Block Blobs* - are composed of blocks and ideal for storing text or binary files, and for uploading large files efficiently
- *Append Blobs* - are also composed of blocks, but they are optimized for append scenarios, making them ideal for logging scenarios
- *Page Blogs* - are made up of 512-byte pages upto 8 TB in total size and are designed for frequent random read/write operations  

# Authorization
| Azure Artifact    | Shared Key (Storage Account Key) | Shared Access Signature (SAS) | Azure Active Directory (Azure AD) | On-Premises Active Directory Domain Services | Anonymous Public Read Access | Storage Local Users |
|-------------------|----------------------------------|-------------------------------|------------------------------------|--------------------------------------------|-----------------------------|---------------------|
| Azure Blobs       | Supported                        | Supported                     | Supported                          | Not supported                             | Supported but not recommended | Supported, only for SFTP |
| Azure Files (SMB) | Supported                        | Not supported                | Supported, only with Azure AD Domain Services for cloud-only or Azure AD Kerberos for hybrid identities | Supported, credentials must be synced to Azure AD | Not supported | Not supported |
| Azure Files (REST)| Supported                        | Supported                     | Supported                          | Not supported                             | Not supported               | Not supported |
| Azure Queues      | Supported                        | Supported                     | Supported                          | Not Supported                            | Not supported               | Not supported |
| Azure Tables      | Supported                        | Supported                     | Supported                          | Not supported                             | Not supported               | Not supported |
