import Menu, { MenuItem } from '../model/basic/Menu'
import User from '../model/identity/User'

export default class RootState {
    user: User = new User()
    antIcons: any = null
    menu: Menu = new Menu()
    currentMenu: MenuItem = new MenuItem()
}
