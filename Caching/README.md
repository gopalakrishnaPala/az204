### Configuring Cache and Expiration Policies in Azure CDN

#### Create a new CDN Profile
- Name
- Resource Group
- Pricing Tier

#### Configure the CDN endpoint
- Name
- Origin type
- Origin hostname   (For resource outside Azure - custom origin with Url)
- Origin path
- Orighin host header

#### Navigate to endpoint url

### How Caching Works
CDN is a
- globally distributed network
- reduced asset load times
- reduced hosting bandwidth
- increased availability and redundancy 
- protection from denial-of-service attacks

#### Content Types
- Static Content (Images, CSS files, JS files)
- Dynamic Content (Changes on user interaction)

```mermaid
graph TD;
    A-->B;
    A-->C;
    B-->D;
    C-->D;
```


