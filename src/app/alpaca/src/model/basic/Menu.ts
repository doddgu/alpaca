export class MenuItem {
    title: string = ''
    link: string = ''
    icon: string = ''
    sub: MenuItem[] = []
}

export default class Menu {
    items: MenuItem[] = [
        // {
        //     title: 'text.environment',
        //     link: '',
        //     icon: 'EnvironmentOutlined',
        //     sub: [{
        //         title: 'text.environment',
        //         actived: false,
        //         link: 'Environment.Manage',
        //         icon: 'EnvironmentOutlined',
        //         sub: []
        //     }]
        // },
        {
            title: 'text.environment',
            link: 'Environment.Manage',
            icon: 'EnvironmentOutlined',
            sub: []
        },
        {
            title: 'text.app',
            link: 'App.Manage',
            icon: 'AppstoreOutlined',
            sub: []
        }
    ]
}
