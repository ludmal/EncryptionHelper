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
