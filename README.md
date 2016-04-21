Simple Encryption Helper Library
==================================

**Nuget Install**

```
Install-Package EncryptionHelper
```

Simple usage 

> Encrypted attribute with properties will automatically encrypt the property when saving to Db using EF.

```javascript
public class Customer
    {
        [Encrypted]
        public string Mobile { get; set; }

        public string Name { get; set; }
    }
```

> Extension methods to encrypt/decrypt any string value

```javascript
var mytext = "niceone";
var encryptedString = mytext.Encrypt();
var decryptedString = encryptedString.Decrypt();
```

**Encryption Key**
Use your own key by simply adding to config file or any other mechanism.
```javascript
<appSettings>
    <add key="EncryptionKey" value="[mykey]" />
</appSettings>
```

