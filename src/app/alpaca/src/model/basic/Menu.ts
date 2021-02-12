class MenuItem {
    title: string = ''
    actived: boolean = false
    link: string = ''
    icon: string = ''
    sub: MenuItem[] = []
}

export default class Menu {
    items: MenuItem[] = [
        // {
        //     title: 'text.environment',
        //     actived: false,
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
            actived: false,
            link: 'Environment.Manage',
            icon: 'EnvironmentOutlined',
            sub: []
        }
    ]
}
