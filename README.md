# Life of a K-Pop Stan

## Android Keystore
  echo "${{ secrets.USER_KEYSTORE }}" > user.keystore.asc
  gpg -d --passphrase "${{ secrets.USER_KEYSTORE_PASSPHRASE }}" --batch user.keystore.asc > user.keystore
