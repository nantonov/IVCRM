import { UserManagerSettings} from "oidc-client";

export const authConfig : UserManagerSettings = {
    authority: "https://localhost:7237",
    client_id: "react-client",
    response_type: "code",
    scope: "openid productAPI",
    redirect_uri: "http://localhost:3000/callback",
    post_logout_redirect_uri: "http://localhost:3000/logout",
    silent_redirect_uri: `http://localhost:3000/refresh`,
    loadUserInfo: true,
};