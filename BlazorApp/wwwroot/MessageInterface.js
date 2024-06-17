export default function Widget() {
    return (
        <div className="flex h-screen">
          <div className="w-1/4 bg-white dark:bg-zinc-800 border-r border-zinc-200 dark:border-zinc-700 p-4">
            <div className="flex items-center mb-4">
              <img src="https://placehold.co/40x40" alt="Profile" className="rounded-full mr-2">
              <span className="font-semibold dark:text-white">My Profile</span>
            </div>
            <div className="flex justify-between mb-4">
              <span className="font-semibold dark:text-white">Matches</span>
              <span className="text-red-500">10</span>
            </div>
            <div className="flex justify-between mb-4">
              <span className="font-semibold dark:text-white">Messages</span>
              <span className="text-red-500">3</span>
            </div>
            <div className="overflow-y-auto">
              <div className="flex items-center p-2 hover:bg-zinc-100 dark:hover:bg-zinc-700 cursor-pointer">
                <img src="https://placehold.co/40x40" alt="Curt" className="rounded-full mr-2">
                <div>
                  <div className="font-semibold dark:text-white">Curt</div>
                  <div className="text-sm text-zinc-500 dark:text-zinc-400">Duck, duck, goose???? N...</div>
                </div>
              </div>
              <div className="flex items-center p-2 hover:bg-zinc-100 dark:hover:bg-zinc-700 cursor-pointer">
                <img src="https://placehold.co/40x40" alt="Shay" className="rounded-full mr-2">
                <div>
                  <div className="font-semibold dark:text-white">Shay</div>
                  <div className="text-sm text-zinc-500 dark:text-zinc-400">Good afternoon</div>
                </div>
              </div>
              <div className="flex items-center p-2 hover:bg-zinc-100 dark:hover:bg-zinc-700 cursor-pointer">
                <img src="https://placehold.co/40x40" alt="Andrew" className="rounded-full mr-2">
                <div>
                  <div className="font-semibold dark:text-white">Andrew</div>
                  <div className="text-sm text-zinc-500 dark:text-zinc-400">Heya. How's it going?</div>
                </div>
              </div>
              <div className="flex items-center p-2 hover:bg-zinc-100 dark:hover:bg-zinc-700 cursor-pointer">
                <img src="https://placehold.co/40x40" alt="Scott" className="rounded-full mr-2">
                <div>
                  <div className="font-semibold dark:text-white">Scott</div>
                  <div className="text-sm text-zinc-500 dark:text-zinc-400">You have sent a BITM...</div>
                </div>
              </div>
              <div className="flex items-center p-2 hover:bg-zinc-100 dark:hover:bg-zinc-700 cursor-pointer">
                <img src="https://placehold.co/40x40" alt="Travis DB" className="rounded-full mr-2">
                <div>
                  <div className="font-semibold dark:text-white">Travis DB</div>
                  <div className="text-sm text-zinc-500 dark:text-zinc-400">👋</div>
                </div>
              </div>
            </div>
          </div>
          
          <div className="w-1/2 bg-white dark:bg-zinc-800 border-r border-zinc-200 dark:border-zinc-700 p-4 flex flex-col">
            <div className="flex items-center mb-4">
              <img src="https://placehold.co/40x40" alt="Shay" className="rounded-full mr-2">
              <span className="font-semibold dark:text-white">You matched with Shay on 11/12/2018</span>
            </div>
            <div className="flex-1 overflow-y-auto">
              <div className="mb-4">
                <div className="bg-zinc-100 dark:bg-zinc-700 p-2 rounded-lg inline-block">Good afternoon</div>
              </div>
            </div>
            <div className="flex items-center p-2 border-t border-zinc-200 dark:border-zinc-700">
              <input type="text" placeholder="Type a message" className="flex-1 border border-zinc-300 dark:border-zinc-600 rounded-lg p-2 mr-2 dark:bg-zinc-800 dark:text-white">
              <button className="bg-zinc-200 dark:bg-zinc-700 text-zinc-500 dark:text-zinc-400 px-4 py-2 rounded-lg">SEND</button>
            </div>
          </div>
          
          <div className="w-1/4 bg-white dark:bg-zinc-800 p-4">
            <img src="https://placehold.co/200x200" alt="Shay" className="rounded-lg mb-4">
            <div className="font-semibold text-xl mb-2 dark:text-white">Shay 40</div>
            <div className="text-zinc-500 dark:text-zinc-400 mb-4">59 miles away</div>
            <div className="flex justify-between">
              <button className="bg-zinc-200 dark:bg-zinc-700 text-zinc-500 dark:text-zinc-400 px-4 py-2 rounded-lg">UNMATCH</button>
              <button className="bg-zinc-200 dark:bg-zinc-700 text-zinc-500 dark:text-zinc-400 px-4 py-2 rounded-lg">REPORT</button>
            </div>
          </div>
        </div>
    )
}