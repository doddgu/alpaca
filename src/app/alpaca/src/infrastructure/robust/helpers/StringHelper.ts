export default class StringHelper {
    static dynamicFormat(template: string, value: any): string {
        return ((v) => {
            return eval('`' + template + '`')
        })(value)
    }
}