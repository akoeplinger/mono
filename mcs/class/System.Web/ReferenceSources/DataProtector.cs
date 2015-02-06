namespace System.Security.Cryptography {

// TODO: move to system assembly
    public abstract class DataProtector
    {
        public static DataProtector Create(string providerClass,
                                           string applicationName,
                                           string primaryPurpose,
                                           params string[] specificPurposes)
        {
            return null;
        }

        public byte[] Protect(byte[] userData)
        {
            throw new NotImplementedException();
        }

        public byte[] Unprotect(byte[] encryptedData)
        {
            throw new NotImplementedException();
        }
    }
}
