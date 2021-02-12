import Menu from '../model/basic/Menu'
import User from '../model/identity/User'
import Snackbar from '../model/robust/Snackbar'

export default class RootState {
    user: User = new User()
    snackbar: Snackbar = new Snackbar()
    overlay: boolean = false
    staticInfo: any = null
    antIcons: any = null
    menu: Menu = new Menu()
}
