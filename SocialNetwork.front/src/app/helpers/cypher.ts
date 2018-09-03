import * as CryptoJS from 'crypto-js';
import { KEY, IV } from './constants'

var key = CryptoJS.enc.Utf8.parse(IV);
var iv = CryptoJS.enc.Utf8.parse(KEY);

export class Cypher {
    public static Encrypt(toEncode) {
        var encryptedlogin = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(toEncode), key,  
        {
           keySize: 128 / 8,   
           iv: iv,  
           mode: CryptoJS.mode.CBC,  
           padding: CryptoJS.pad.Pkcs7 
        });
        
        return encryptedlogin;
    }

    public static Decrypt(encrypted) {
        return CryptoJS.AES.decrypt(encrypted, key, {
            keySize: 128 / 8,
            iv: iv,
            mode: CryptoJS.mode.CBC,
            padding: CryptoJS.pad.Pkcs7
        });
    }

    public static DecryptString(decrypted: CryptoJS.DecryptedMessage){
        return decrypted.toString(CryptoJS.enc.Utf8);
    }
}