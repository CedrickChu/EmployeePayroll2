window.encryptionHelper = {
    secretKey: "your-secret-key",

    encryptData: function (data) {
        return CryptoJS.AES.encrypt(JSON.stringify(data), this.secretKey).toString();
    },

    decryptData: function (cipherText) {
        try {
            let bytes = CryptoJS.AES.decrypt(cipherText, this.secretKey);
            return JSON.parse(bytes.toString(CryptoJS.enc.Utf8));
        } catch (e) {
            console.error("Decryption failed", e);
            return null;
        }
    },

    saveToLocalStorage: function (key, data) {
        localStorage.setItem(key, this.encryptData(data));
    },

    getFromLocalStorage: function (key) {
        let encryptedData = localStorage.getItem(key);
        return encryptedData ? this.decryptData(encryptedData) : null;
    },

    saveToSessionStorage: function (key, data) {
        sessionStorage.setItem(key, this.encryptData(data));
    },

    getFromSessionStorage: function (key) {
        let encryptedData = sessionStorage.getItem(key);
        return encryptedData ? this.decryptData(encryptedData) : null;
    }
};
