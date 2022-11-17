import { User, UserManager } from 'oidc-client';
import { authConfig } from '../config/authConfig';

/*
https://github.com/authts/sample-angular-oidc-client-ts/blob/main/src/app/core/services/auth.service.ts
example
*/

const userManager = new UserManager(authConfig)

export default class AuthService {
  static async getUser() : Promise<User | null> {
    var user =  await userManager.getUser()
    console.log(user)
    return user
  }

  static async signIn(): Promise<void> {
    return await userManager.signinRedirect()
  }

  static async signInCallback(): Promise<User> {
    return await userManager.signinRedirectCallback()
  }

  static async signOut(): Promise<void> {
    var userTokenId = (await userManager.getUser())?.id_token

    userManager.clearStaleState()
    userManager.removeUser()
    await userManager.signoutRedirect({id_token_hint: userTokenId});
  }

  static async signOutCallback(): Promise<void> {
    await userManager.signoutRedirectCallback()
  }

  static async signInSilentCallback(): Promise<void> {
    await userManager.signinSilentCallback();
  }

  static async signInSilent(): Promise<void> {
    await userManager.signinSilentCallback();
  }
}