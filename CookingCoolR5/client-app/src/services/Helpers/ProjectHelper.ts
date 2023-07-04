export default class ProjectHelper {

    public static get isDevelopment(): boolean {
        return !process.env.NODE_ENV || process.env.NODE_ENV === 'development';
    }

    public static get isProduction(): boolean {
        if (!process.env.NODE_ENV)
            return false;

        return process.env.NODE_ENV === 'production';
    }
}