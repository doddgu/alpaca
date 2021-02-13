import i18n from "../../../config/i18n-config";
import StringHelper from "./StringHelper";

export default class I18nHelper {
    static dt(key: string, v: any = null): string {
        return StringHelper.dynamicFormat(i18n.global.t(key), v)
    }

    static t(key: string): string {
        return i18n.global.t(key)
    }
}